using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SoftwarerAchitecture.DBUtility.BaseWork;
using SoftwarerAchitecture.Models.DbMainInterface;
using SoftwarerAchitecture.Service.MainInterfaceService;
using SoftwarerAchitecture.Service.MainWebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwarerAchitecture.Modules.MainInterface
{
    public partial class MainInterface : Form
    {
        TaskService taskService = new TaskService();
        /// <summary>
        /// 任务类
        /// </summary>
        SearchLineService LineService = new SearchLineService();
        /// <summary>
        /// 数据操作类
        /// </summary>
        SearchResultService ResultService = new SearchResultService();
        /// <summary>
        /// 线程状态
        /// </summary>
        bool flagStop = false;
        /// <summary>
        /// 随机值
        /// </summary>
        Random ran = new Random();
        /// <summary>
        /// 程序支持航司列表
        /// </summary>
        string AirLineStr = "MU,9C,SC,8L,MF,ZH";
        /// <summary>
        /// 数据字典
        /// </summary>
        public static NavCode Dic = new NavCode();
        /// <summary>
        /// 委托显示数据抓取进度
        /// </summary>
        /// <param name="Index"></param>
        delegate void InvokeDelegate(object Index);
        public void InvokeList(object mes)
        {
            if (listBox1.Items.Count > 40)
            {
                listBox1.Items.RemoveAt(0);
                listBox1.Items.RemoveAt(0);
            }
            listBox1.Items.Add(mes);
            this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
        }

        public MainInterface()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainInterface_Load(object sender, EventArgs e)
        {
            //LoadTreeView();

            LoadGridView();
            Dic = JsonConvert.DeserializeObject<NavCode>(BaseController.NavCode);
        }

        private void LoadGridView()
        {
            dataGridView1.DataSource = null;
            var list = LineService.SvcAdapter.GetList(a => a.IsAccessTask == false).Select(a => new
            {
                a.AirLine,
                a.ArrivalCityCode,
                a.DepartureCityCode,
                a.Interval,
                a.IsAccessTask,
                a.LastDay,
                a.Days
            }).ToList();
            dataGridView1.DataSource = list;
        }
        /// <summary>
        /// 加载任务树
        /// </summary>
        private void LoadTreeView()
        {
            List<TaskList> list = taskService.SvcAdapter.GetList(a => a.IsValid.Value && a.ParentId.Value == 0);
            foreach (TaskList task in list)
            {
                //循环数据视图，将对应的值交给一个节点对象，然后添加到树上有继续添加
                TreeNode tn = new TreeNode();
                tn.Text = task.TaskName;
                tn.Tag = task.TaskId;
                treeView1.Nodes.Add(tn);
                AddchildNodes(tn);//调用方法填充二级节点
            }
        }
        /// <summary>
        /// 循环加载
        /// </summary>
        /// <param name="tn"></param>
        private void AddchildNodes(TreeNode tn)
        {
            int bid = Convert.ToInt32(tn.Tag);
            List<TaskList> list = taskService.SvcAdapter.GetList(a => a.IsValid.Value && a.ParentId == bid);
            foreach (TaskList taskinfo in list)
            {
                TreeNode ctn = new TreeNode();
                ctn.Text = taskinfo.TaskName;
                ctn.Tag = taskinfo.TaskId;
                tn.Nodes.Add(ctn);
                AddchildNodes(ctn);
            }
        }
        /// <summary>
        /// 判断当前选中的节点，根据节点不同设置不同的右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            treeView1.ContextMenuStrip = null;
            TreeNode selectNode = treeView1.GetNodeAt(e.X, e.Y);
            if (selectNode.Level == 1)
            {
                treeView1.ContextMenuStrip = TreeViewContextMenu;
            }
        }
        /// <summary>
        /// 启动抓取任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            address.Text = UtilController.GetIP();
            Thread th = new Thread(AirLineWork);
            th.Start();
        }
        /// <summary>
        /// 机票抓取线程
        /// </summary>
        /// <param name="urltxt"></param>
        private void AirLineWork()
        {
            while (!flagStop)
            {
                try
                {
                    while (!flagStop)
                    {
                        SearchLine TaskInfo = LineService.SvcAdapter.GetList(a => a.IsAccessTask == false).OrderBy(a => a.GatherTime).FirstOrDefault();

                        if (TaskInfo != null)
                        {
                            int id = TaskInfo.ID;
                            string AirLine = TaskInfo.AirLine;
                            string DepartureCityCode = TaskInfo.DepartureCityCode;
                            string ArrivalCityCode = TaskInfo.ArrivalCityCode;
                            int Interval = TaskInfo.Interval.Value * 1000;
                            int Days = TaskInfo.Days.Value;
                            string IsInter = TaskInfo.IsInter.ToString();
                            int LastDay = TaskInfo.LastDay.Value;

                            TaskInfo.IsAccessTask = true;
                            TaskInfo.GatherIP = address.Text.Trim();
                            TaskInfo.GatherTime = DateTime.Now;

                            bool result = LineService.SvcAdapter.UpdateObject(TaskInfo);

                            if (result)
                            {
                                //从第几天开始
                                DateTime dt1 = DateTime.Now;
                                for (int i = LastDay; i <= Days - 1; i++)
                                {
                                    string datestr = dt1.AddDays(i).ToString("yyyy-MM-dd");
                                    Thread.Sleep(Interval);
                                    if (flagStop)
                                    {
                                        break;
                                    }
                                    string liststr = "[" + DateTime.Now.ToString() + "] 机票//" + AirLine + "//" + DepartureCityCode + "//" + ArrivalCityCode + "//" + datestr;
                                    listBox1.Invoke(new InvokeDelegate(InvokeList), liststr);
                                    string s = string.Empty;
                                    if (AirLine == "MU")
                                    {
                                        s = GetMU(DepartureCityCode, ArrivalCityCode, IsInter, datestr, Interval);

                                    }
                                    else if (AirLine == "9C")
                                    {
                                        s = Get9C(DepartureCityCode, ArrivalCityCode, IsInter, datestr, Interval);

                                    }
                                    else if (AirLine == "SC")
                                    {
                                        s = GetSC(DepartureCityCode, ArrivalCityCode, IsInter, datestr, Interval);

                                    }
                                    else if (AirLine == "8L")
                                    {
                                        s = Get8L(DepartureCityCode, ArrivalCityCode, IsInter, datestr, Interval);

                                    }
                                    else if (AirLine == "MF")
                                    {
                                        s = GetMF(DepartureCityCode, ArrivalCityCode, IsInter, datestr, Interval);

                                    }
                                    else if (AirLine == "ZH")
                                    {
                                        s = GetZH(DepartureCityCode, ArrivalCityCode, IsInter, datestr, Interval);

                                    }
                                    if (s.StartsWith("Err") || s.IndexOf("频繁") >= 0)
                                    {
                                        break;
                                    }
                                    TaskInfo.LastDay = i + 1;
                                    LineService.SvcAdapter.UpdateObject(TaskInfo);
                                }
                                if (TaskInfo.LastDay == TaskInfo.Days)
                                {
                                    TaskInfo.LastDay = 0;
                                    TaskInfo.IsAccessTask = false;
                                    LineService.SvcAdapter.UpdateObject(TaskInfo);
                                }
                            }
                        }
                        if (flagStop)
                        {
                            System.Environment.Exit(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (flagStop)
                    {
                        System.Environment.Exit(0);
                    }
                    string liststr = "错误信息：" + ex.Message + " 再次尝试连接中...";
                    listBox1.Invoke(new InvokeDelegate(InvokeList), liststr);
                }
                Thread.Sleep(10000);
            }
        }

        private string GetMU(string DepartureCityCode, string ArrivalCityCode, string IsInter, string datestr, int Interval)
        {
            int icount = 0;
            double r = ran.NextDouble();
            string 航司 = "MU";
            string 出发 = DepartureCityCode;
            string 到达 = ArrivalCityCode;
            string 日期 = datestr;
            double 更新批次 = r;
            string url = "http://www.ceair.com/otabooking/flight-search!doFlightSearch.shtml?rand=" + r.ToString();
            string postpara = "searchCond={\"tripType\":\"OW\",\"adtCount\":1,\"chdCount\":0,\"infCount\":0,\"currency\":\"CNY\",\"sortType\":\"a\",\"segmentList\":[{\"deptCd\":\"" + DepartureCityCode + "\",\"arrCd\":\"" + ArrivalCityCode + "\",\"deptDt\":\"" + datestr + "\",\"deptAirport\":\"\",\"arrAirport\":\"\",\"deptCdTxt\":\"\",\"arrCdTxt\":\"\",\"deptCityCode\":\"" + DepartureCityCode + "\",\"arrCityCode\":\"" + ArrivalCityCode + "\"}],\"sortExec\":\"a\",\"page\":\"0\"}";
            string s = BaseController.GetPage(url, postpara, null, false, "UTF-8");
            JsonSerializerSettings js = new JsonSerializerSettings();
            js.NullValueHandling = NullValueHandling.Ignore;
            try
            {
                if (s.StartsWith("Err") || s.Contains("极为频繁"))
                {
                    throw new ArgumentException(s);
                }
                Root flights = JsonConvert.DeserializeObject<Root>(s, js);
                for (int j = 1; j <= flights.pageSize; j++)
                {
                    if (j >= 2)
                    {
                        //Thread.Sleep(i间隔);
                        r = ran.NextDouble();
                        url = "http://www.ceair.com/otabooking/flight-search!doFlightSearch.shtml?rand=" + r.ToString();
                        postpara = "searchCond={\"tripType\":\"OW\",\"adtCount\":1,\"chdCount\":0,\"infCount\":0,\"currency\":\"CNY\",\"sortType\":\"a\",\"segmentList\":[{\"deptCd\":\"" + DepartureCityCode + "\",\"arrCd\":\"" + ArrivalCityCode + "\",\"deptDt\":\"" + datestr + "\",\"deptAirport\":\"\",\"arrAirport\":\"\",\"deptCdTxt\":\"\",\"arrCdTxt\":\"\",\"deptCityCode\":\"" + DepartureCityCode + "\",\"arrCityCode\":\"" + ArrivalCityCode + "\"}],\"sortExec\":\"a\",\"page\":\"p" + (j - 1).ToString() + "\",\"inter\":1}";
                        s = BaseController.GetPage(url, postpara, null, false);
                        if (s.StartsWith("Err") || s.Contains("极为频繁"))
                        {
                            throw new ArgumentException(s);
                        }
                        flights = JsonConvert.DeserializeObject<Root>(s, js);
                    }
                    for (int i = 0; i <= flights.airResultDto.productUnits.Count - 1; i++)
                    {
                        //string 航线组 = flights.airResultDto.productUnits[i].flightNoGroup;       
                        if (flights.airResultDto.productUnits[i].productInfo.purpose != null)
                        {
                            if (flights.airResultDto.productUnits[i].productInfo.purpose.Contains("空铁联运"))
                            {
                                continue;
                            }
                        }
                        string 价格1 = flights.airResultDto.productUnits[i].fareInfoView[0].fare.salePrice;
                        string 税费1 = flights.airResultDto.productUnits[i].fareInfoView[0].fare.referenceTax;
                        //国内不显示税费，统一是50，国外显示税费
                        if (税费1 == null)
                        {
                            税费1 = "null";
                        }
                        string 价格2 = "null";
                        string 税费2 = "null";

                        string 航班号1 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[0].flightNumber;
                        string 舱位1 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[0].bookingClassAvail.cabinCode;
                        string 舱位余量1 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[0].bookingClassAvail.cabinStatusCode;
                        string 出发1 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[0].departureAirport.code;
                        string 到达1 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[0].arrivalAirport.code;
                        string 起飞时间1 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[0].departureDateTime;
                        string 到达时间1 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[0].arrivalDateTime;
                        if (!航班号1.Contains("MU") && !航班号1.Contains("FM"))
                        {
                            continue;
                        }

                        string 航班号2 = "";
                        string 舱位2 = "";
                        string 舱位余量2 = "";
                        string 出发2 = "";
                        string 到达2 = "";
                        string 起飞时间2 = "";
                        string 到达时间2 = "";

                        if (flights.airResultDto.productUnits[i].oriDestOption[0].flights.Count <= 1)
                        {
                        }
                        else if (flights.airResultDto.productUnits[i].oriDestOption[0].flights.Count == 2)
                        {
                            航班号2 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[1].flightNumber;
                            舱位2 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[1].bookingClassAvail.cabinCode;
                            舱位余量2 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[1].bookingClassAvail.cabinStatusCode;
                            出发2 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[1].departureAirport.code;
                            到达2 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[1].arrivalAirport.code;
                            起飞时间2 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[1].departureDateTime;
                            到达时间2 = flights.airResultDto.productUnits[i].oriDestOption[0].flights[1].arrivalDateTime;
                            if (!航班号2.Contains("MU") && !航班号2.Contains("FM"))
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                        SearchResult Result = new SearchResult();


                        Result.AirLine = 航司;
                        Result.AirLineName = "中国东方航空";
                        Result.AirportPrice = 税费1;
                        Result.ArrivalCityCode = ArrivalCityCode;
                        Result.ArrivalTime = DateTime.Parse(到达时间1);
                        Result.BookUrl = "http://www.ceair.com/flight2014/";
                        Result.ClassCode = 舱位1;
                        Result.DepartureCityCode = DepartureCityCode;
                        Result.DepartureTime = DateTime.Parse(起飞时间1);
                        Result.FlightNo = 航班号1;
                        Result.IsInter = IsInter;
                        Result.Storage = 舱位余量1;
                        Result.TicketPrice = float.Parse(价格1);
                        Result.DepDateTime = datestr;
                        Result.UpdateBatch = 更新批次;
                        Result.UpdateTime = DateTime.Now;

                        foreach (var item in Dic.cityArray)
                        {
                            foreach (var item1 in item.tabdata)
                            {
                                foreach (var item2 in item1.dd)
                                {
                                    if (item2.cityCode == ArrivalCityCode)
                                    {
                                        Result.ArrivalCity = item2.cityName;
                                        break;
                                    }
                                    else if (item2.cityCode == DepartureCityCode)
                                    {
                                        Result.DepartureCity = item2.cityName;
                                        break;
                                    }
                                }
                                if (!string.IsNullOrEmpty(Result.ArrivalCity) && !string.IsNullOrEmpty(Result.DepartureCity))
                                {
                                    break;
                                }
                            }
                            if (!string.IsNullOrEmpty(Result.ArrivalCity) && !string.IsNullOrEmpty(Result.DepartureCity))
                            {
                                break;
                            }
                        }
                        ResultService.SvcAdapter.AddObject(Result);
                        icount++;
                    }
                }
                string liststr = "[" + DateTime.Now.ToString() + "] 机票//" + 航司 + "//" + 出发 + "//" + 到达 + "//" + 日期 + "//采集到共" + icount.ToString() + "条数据";
                listBox1.Invoke(new InvokeDelegate(InvokeList), liststr);
                var temp = ResultService.SvcAdapter.GetList(a => a.AirLine == 航司 && a.DepartureCityCode == DepartureCityCode && a.ArrivalCityCode == ArrivalCityCode && a.DepDateTime == datestr && a.UpdateBatch != 更新批次);
                if (temp != null)
                {
                    ResultService.SvcAdapter.DeleteObject(temp);
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
            }
            return s;
        }

        private string Get9C(string DepartureCityCode, string ArrivalCityCode, string IsInter, string datestr, int Interval)
        {
            int icount = 0;
            double r = ran.NextDouble();
            string 航司 = "9C";
            string 出发 = DepartureCityCode;
            string 到达 = ArrivalCityCode;
            string 日期 = datestr;
            double 更新批次 = r;
            string url = "https://flights.ch.com/Flights/SearchByTime";
            string postpara = "Currency=0&SType=0&Departure=" + 出发 + "&Arrival=" + 到达 + "&DepartureDate=" + 日期 + "&ReturnDate=null&IsIJFlight=false&IsBg=false&IsEmployee=false&IsLittleGroupFlight=false&SeatsNum=1&ActId=0&IfRet=false&IsShowTaxprice=true";
            string s = BaseController.GetPage(url, postpara, null, false, "UTF-8");
            JsonSerializerSettings js = new JsonSerializerSettings();
            js.NullValueHandling = NullValueHandling.Ignore;
            //遇到没有结构如何解析MissingMemberHandling
            try
            {
                if (s.StartsWith("Err") || s.Contains("频率太快"))
                {
                    throw new ArgumentException(s);
                }
                Root9C flights = JsonConvert.DeserializeObject<Root9C>(s, js);
                for (int i = 0; i <= flights.Route.Count - 1; i++)
                {
                    string 税费1 = "null";
                    //国际是含税价、国内是裸价
                    //{
                    //    税费1 = flights.Route[i][0].RouteTotalTax.ToString();
                    //}
                    string 价格2 = "null";
                    string 税费2 = "null";

                    string 航班号1 = flights.Route[i][0].No;
                    string 出发1 = flights.Route[i][0].DepartureAirportCode;
                    string 到达1 = flights.Route[i][0].ArrivalAirportCode;
                    string 起飞时间1 = flights.Route[i][0].DepartureTime;
                    string 到达时间1 = flights.Route[i][0].ArrivalTime;
                    //if (!航班号1.Contains("MU") && !航班号1.Contains("FM"))
                    //{
                    //    continue;
                    //}

                    string 航班号2 = "";
                    string 舱位2 = "";
                    string 舱位余量2 = "";
                    string 出发2 = "";
                    string 到达2 = "";
                    string 起飞时间2 = "";
                    string 到达时间2 = "";

                    for (int j = 0; j <= flights.Route[i][0].AircraftCabins.Count - 1; j++)
                    {
                        string 舱位1 = flights.Route[i][0].AircraftCabins[j].AircraftCabinInfos[0].Name;
                        string 舱位余量1 = flights.Route[i][0].AircraftCabins[j].AircraftCabinInfos[0].Remain.ToString();
                        if (舱位余量1 == "0")
                        {
                            舱位余量1 = "A";
                        }
                        string 价格1 = flights.Route[i][0].AircraftCabins[j].AircraftCabinInfos[0].Price.ToString();

                        SearchResult Result = new SearchResult();
                        Result.AirLine = 航司;
                        Result.AirLineName = "春秋航空";
                        Result.AirportPrice = 税费1;
                        Result.ArrivalCityCode = ArrivalCityCode;
                        Result.ArrivalTime = DateTime.Parse(到达时间1);
                        Result.BookUrl = "https://flights.ch.com/";
                        Result.ClassCode = 舱位1;
                        Result.DepartureCityCode = DepartureCityCode;
                        Result.DepartureTime = DateTime.Parse(起飞时间1);
                        Result.FlightNo = 航班号1;
                        Result.IsInter = IsInter;
                        Result.Storage = 舱位余量1;
                        Result.TicketPrice = float.Parse(价格1);
                        Result.DepDateTime = datestr;
                        Result.UpdateBatch = 更新批次;
                        Result.UpdateTime = DateTime.Now;
                        foreach (var item in Dic.cityArray)
                        {
                            foreach (var item1 in item.tabdata)
                            {
                                foreach (var item2 in item1.dd)
                                {
                                    if (item2.cityCode == ArrivalCityCode)
                                    {
                                        Result.ArrivalCity = item2.cityName;
                                        break;
                                    }
                                    else if (item2.cityCode == DepartureCityCode)
                                    {
                                        Result.DepartureCity = item2.cityName;
                                        break;
                                    }
                                }
                                if (!string.IsNullOrEmpty(Result.ArrivalCity) && !string.IsNullOrEmpty(Result.DepartureCity))
                                {
                                    break;
                                }
                            }
                            if (!string.IsNullOrEmpty(Result.ArrivalCity) && !string.IsNullOrEmpty(Result.DepartureCity))
                            {
                                break;
                            }
                        }
                        ResultService.SvcAdapter.AddObject(Result);
                        icount++;
                    }
                }
                string liststr = "[" + DateTime.Now.ToString() + "] 机票//" + 航司 + "//" + 出发 + "//" + 到达 + "//" + 日期 + "//采集到" + flights.Route.Count.ToString() + "个航班，共" + icount.ToString() + "条数据";
                listBox1.Invoke(new InvokeDelegate(InvokeList), liststr);
                var temp = ResultService.SvcAdapter.GetList(a => a.AirLine == 航司 && a.DepartureCityCode == DepartureCityCode && a.ArrivalCityCode == ArrivalCityCode && a.DepDateTime == datestr && a.UpdateBatch != 更新批次);
                if (temp != null)
                {
                    ResultService.SvcAdapter.DeleteObject(temp);
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
            }
            return s;
        }

        private string GetSC(string DepartureCityCode, string ArrivalCityCode, string IsInter, string datestr, int Interval)
        {
            CookieCollection m_cookies = new CookieCollection();
            int icount = 0;
            double r = ran.NextDouble();
            string 航司 = "SC";
            //string 出发 = src;
            //string 到达 = dst;
            //string 日期 = datestr;
            double 更新批次 = r;
            string url = "http://sc.travelsky.com/scet/queryAv.do";
            string postpara = "countrytype=0&travelType=0&cityNameOrg=&cityCodeOrg=" + DepartureCityCode + "&cityNameDes=&cityCodeDes=" + ArrivalCityCode + "&takeoffDate=" + datestr + "&returnDate=&cabinStage=0&adultNum=1&childNum=0";
            string s = BaseController.GetPage(url, postpara, m_cookies, true);
            int ine1 = 0;
            string airAvailId = BaseController.CutString("name =\"airAvailId\"", s, "value=\"", "\"", ref ine1);

            url = "http://sc.travelsky.com/scet/airAvail.do";
            postpara = "airAvailId=" + airAvailId// Module2.GetTimeLikeJS().ToString() 
                            + "&cityCodeOrg=" + DepartureCityCode
                            + "&cityCodeDes=" + ArrivalCityCode
                            + "&cityNameOrg=&cityNameDes=&takeoffDate=" + datestr + "&travelType=0&countrytype=0&needRT=0&cabinStage=0&adultNum=1&childNum=0";
            s = BaseController.GetPage(url, postpara, m_cookies, true);
            //JsonSerializerSettings js = new JsonSerializerSettings();
            //js.NullValueHandling = NullValueHandling.Ignore;
            //遇到没有结构如何解析MissingMemberHandling
            try
            {
                if (s.StartsWith("Err") || s.Contains("访问受限"))
                {
                    throw new ArgumentException(s);
                }
                string 出发1 = BaseController.CutString(1, s, "chartscodeOrg = \"", "\"", ref ine1);
                string 到达1 = BaseController.CutString(1, s, "chartscodeDes = \"", "\"", ref ine1);

                string record_prise = BaseController.CutString(1, s, "<div class=\"record record-prise\">", "<div id=\"noFlightGo", ref ine1);
                string[] cabin_tables = Regex.Split(record_prise, "<table class=\"__cabin_table__\">");
                for (int i = 1; i <= cabin_tables.Length - 1; i++)
                {
                    string 价格2 = "null";
                    string 税费2 = "null";

                    string 航班号1 = BaseController.CutString(1, cabin_tables[i], "class=\"dashed\">", "</a>", ref ine1).Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");
                    string 起飞时间1 = BaseController.CutString(1, cabin_tables[i], "departuredatetime=\"", "\"", ref ine1);
                    string 到达时间1 = BaseController.CutString(1, cabin_tables[i], "arrivaldatetime=\"", "\"", ref ine1);

                    string 航班号2 = "";
                    string 舱位2 = "";
                    string 舱位余量2 = "";
                    string 出发2 = "";
                    string 到达2 = "";
                    string 起飞时间2 = "";
                    string 到达时间2 = "";

                    //string[] cols = Regex.Split(cabin_tables[i], "<td class=\"col");
                    string[] choose_cabintables = Regex.Split(cabin_tables[i], "<td class=\"choose-cabintable\"");
                    for (int j = 1; j <= choose_cabintables.Length - 1; j++)
                    {
                        string 舱位1 = BaseController.CutString(1, choose_cabintables[j], "data-classcode=\"", "\"", ref ine1);
                        if (舱位1 == "")
                        {
                            continue;
                        }
                        string 舱位余量1 = BaseController.CutString("舱&nbsp;", choose_cabintables[j], ">", "</p>", ref ine1).Replace(" ", "").Replace("个", "");
                        if (舱位余量1 == "充足")
                        {
                            舱位余量1 = "A";
                        }
                        string 价格1 = BaseController.CutString(1, choose_cabintables[j], "data-price=\"", "\"", ref ine1);
                        string 税费1 = BaseController.CutString(1, choose_cabintables[j], "data-tax=\"", "\"", ref ine1);

                        SearchResult Result = new SearchResult();
                        Result.AirLine = 航司;
                        Result.AirLineName = "山东航空";
                        Result.AirportPrice = 税费1;
                        Result.ArrivalCityCode = ArrivalCityCode;
                        Result.ArrivalTime = DateTime.Parse(到达时间1);
                        Result.BookUrl = "http://www.sda.cn/";
                        Result.ClassCode = 舱位1;
                        Result.DepartureCityCode = DepartureCityCode;
                        Result.DepartureTime = DateTime.Parse(起飞时间1);
                        Result.FlightNo = 航班号1;
                        Result.IsInter = IsInter;
                        Result.Storage = 舱位余量1;
                        Result.TicketPrice = float.Parse(价格1);
                        Result.DepDateTime = datestr;
                        Result.UpdateBatch = 更新批次;
                        Result.UpdateTime = DateTime.Now;
                        foreach (var item in Dic.cityArray)
                        {
                            foreach (var item1 in item.tabdata)
                            {
                                foreach (var item2 in item1.dd)
                                {
                                    if (item2.cityCode == ArrivalCityCode)
                                    {
                                        Result.ArrivalCity = item2.cityName;
                                        break;
                                    }
                                    else if (item2.cityCode == DepartureCityCode)
                                    {
                                        Result.DepartureCity = item2.cityName;
                                        break;
                                    }
                                }
                                if (!string.IsNullOrEmpty(Result.ArrivalCity) && !string.IsNullOrEmpty(Result.DepartureCity))
                                {
                                    break;
                                }
                            }
                            if (!string.IsNullOrEmpty(Result.ArrivalCity) && !string.IsNullOrEmpty(Result.DepartureCity))
                            {
                                break;
                            }
                        }
                        ResultService.SvcAdapter.AddObject(Result);

                        icount++;
                    }
                }
                string liststr = "[" + DateTime.Now.ToString() + "] 机票//" + 航司 + "//" + DepartureCityCode + "//" + ArrivalCityCode + "//" + datestr + "//采集到" + (cabin_tables.Length - 1).ToString() + "个航班，共" + icount.ToString() + "条数据";
                listBox1.Invoke(new InvokeDelegate(InvokeList), liststr);
                var temp = ResultService.SvcAdapter.GetList(a => a.AirLine == 航司 && a.DepartureCityCode == DepartureCityCode && a.ArrivalCityCode == ArrivalCityCode && a.DepDateTime == datestr && a.UpdateBatch != 更新批次);
                if (temp != null)
                {
                    ResultService.SvcAdapter.DeleteObject(temp);
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
            }
            return s;
        }

        private string Get8L(string DepartureCityCode, string ArrivalCityCode, string IsInter, string datestr, int Interval)
        {
            CookieCollection m_cookies = new CookieCollection();
            int icount = 0;
            double r = ran.NextDouble();
            string 航司 = "8L";
            double 更新批次 = r;

            string url = "http://www.luckyair.net/";
            string s = BaseController.GetPage(url, "", m_cookies, true, "UTF-8");

            url = "http://www.luckyair.net/flightresult/flightresult2016.action";
            string postpara = "orgCity=" + DepartureCityCode + "&dstCity=" + ArrivalCityCode + "&flightDate=" + datestr + "&index=1&flightseq=1&desc=FsODuR1dkdOqCZ7WVBRLLq/C4ajJ%2BWxG8GSILQGxarsPn/yADf2tnxMaCHSemZebExntGa7ISxFBqiE4MsAkN7oy8zO/zvcqPbCuvH8tdwbrd9PCpOB3QR2NGRd4oC%2B2KbaLX0uzRxa1vAK/exiFH4VcQLv/VU%2BiGsLujjFu1%2BdqC769zY7fUxD2whfZY/dXlZgRDnONm5xlCpVPZ%2BxnTkS26VCEsZ%2BVcOmXp0s2LsTQfL1ucJ54GY%2BMf6hqu59zWJOML6V4/7NcD8SHBn4%2BuwHwjzlFwTtDzxxOX7DfHLuIwnKP/Z3XBKy8Ogib5zcmPpTMyl4sogcgnEe9EaQsdQ==&tripType=ONEWAY";
            s = BaseController.GetPage(url, postpara, m_cookies, true, "UTF-8");
            int ine1 = 0;
            try
            {
                if (s.StartsWith("Err") || s.Contains("访问受限"))
                {
                    throw new ArgumentException(s);
                }
                string[] cabin_tables = Regex.Split(s, "<div class=\"dis_in_div m_t_15 cabin_con\"");
                for (int i = 1; i <= cabin_tables.Length - 1; i++)
                {
                    string 价格2 = "null";
                    string 税费2 = "null";

                    string 航班号1 = BaseController.CutString(1, cabin_tables[i], "flightNo='", "'", ref ine1);
                    string 起飞时间1 = BaseController.CutString(1, cabin_tables[i], "depTime=\"", "\"", ref ine1);
                    string 到达时间1 = BaseController.CutString(1, cabin_tables[i], "arrTime=\"", "\"", ref ine1);

                    string 航班号2 = "";
                    string 舱位2 = "";
                    string 舱位余量2 = "";
                    string 出发2 = "";
                    string 到达2 = "";
                    string 起飞时间2 = "";
                    string 到达时间2 = "";

                    string[] choose_cabintables = Regex.Split(cabin_tables[i], "tag='cabinPrice'");
                    for (int j = 1; j <= choose_cabintables.Length - 1; j++)
                    {
                        string flg = BaseController.CutString(1, choose_cabintables[j], "flg=\"", "\"", ref ine1);
                        string[] flgs = flg.Split(';');
                        string 舱位1 = flgs[0];
                        string 舱位余量1 = BaseController.CutString(1, choose_cabintables[j], "剩余", "张", ref ine1);
                        if (舱位余量1 == "")
                        {
                            舱位余量1 = "A";
                        }
                        string 出发1 = flgs[3];
                        string 到达1 = flgs[4];
                        string 价格1 = flgs[8];
                        string 税费1 = flgs[9];

                        SearchResult Result = new SearchResult();
                        Result.AirLine = 航司;
                        Result.AirLineName = "祥鹏航空";
                        Result.AirportPrice = 税费1;
                        Result.ArrivalCityCode = ArrivalCityCode;
                        Result.ArrivalTime = DateTime.Parse(到达时间1);
                        Result.BookUrl = "http://www.luckyair.net/";
                        Result.ClassCode = 舱位1;
                        Result.DepartureCityCode = DepartureCityCode;
                        Result.DepartureTime = DateTime.Parse(起飞时间1);
                        Result.FlightNo = 航班号1;
                        Result.IsInter = IsInter;
                        Result.Storage = 舱位余量1;
                        Result.TicketPrice = float.Parse(价格1);
                        Result.DepDateTime = datestr;
                        Result.UpdateBatch = 更新批次;
                        Result.UpdateTime = DateTime.Now;
                        foreach (var item in Dic.cityArray)
                        {
                            foreach (var item1 in item.tabdata)
                            {
                                foreach (var item2 in item1.dd)
                                {
                                    if (item2.cityCode == ArrivalCityCode)
                                    {
                                        Result.ArrivalCity = item2.cityName;
                                        break;
                                    }
                                    else if (item2.cityCode == DepartureCityCode)
                                    {
                                        Result.DepartureCity = item2.cityName;
                                        break;
                                    }
                                }
                                if (!string.IsNullOrEmpty(Result.ArrivalCity) && !string.IsNullOrEmpty(Result.DepartureCity))
                                {
                                    break;
                                }
                            }
                            if (!string.IsNullOrEmpty(Result.ArrivalCity) && !string.IsNullOrEmpty(Result.DepartureCity))
                            {
                                break;
                            }
                        }
                        ResultService.SvcAdapter.AddObject(Result);
                        icount++;
                    }
                }
                string liststr = "[" + DateTime.Now.ToString() + "] 机票//" + 航司 + "//" + DepartureCityCode + "//" + ArrivalCityCode + "//" + datestr + "//采集到" + (cabin_tables.Length - 1).ToString() + "个航班，共" + icount.ToString() + "条数据";
                listBox1.Invoke(new InvokeDelegate(InvokeList), liststr);
                var temp = ResultService.SvcAdapter.GetList(a => a.AirLine == 航司 && a.DepartureCityCode == DepartureCityCode && a.ArrivalCityCode == ArrivalCityCode && a.DepDateTime == datestr && a.UpdateBatch != 更新批次);
                if (temp != null)
                {
                    ResultService.SvcAdapter.DeleteObject(temp);
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
            }
            return s;
        }

        private string GetMF(string DepartureCityCode, string ArrivalCityCode, string IsInter, string datestr, int Interval)
        {
            CookieCollection m_cookies = new CookieCollection();
            int icount = 0;
            double r = ran.NextDouble();
            string 航司 = "MF";
            double 更新批次 = r;

            string url = "https://et.xiamenair.com/xiamenair/book/findFlights.action?tripType=0&queryFlightInfo=" + DepartureCityCode + "," + ArrivalCityCode + "," + datestr + "&cabinClass=1&psgrInfo=0,1;1,0";
            string s = BaseController.GetPage(url, "", m_cookies, true, "UTF-8");

            //获取四位随机数字
            string Rantxt = string.Empty;
            Match Rantxtlist = Regex.Match(s, @"<input id=""random"" [\s\S]*?value=""(?<value>.*?)"">");
            if (Rantxtlist.Groups.Count <= 0)
            {
                return "Err 未搜索到网站的访问限制编码!";
            }
            Rantxt = Rantxtlist.Groups["value"].ToString();

            //时间戳
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1);
            string temp = ts.TotalMilliseconds.ToString().Substring(0, ts.TotalMilliseconds.ToString().IndexOf('.'));

            url = "https://et.xiamenair.com/xiamenair/book/findFlights.json?r=" + Rantxt + "&lang=zh&takeoffDate=" + datestr + "&returnDate=&orgCity=" + DepartureCityCode + "&dstCity=" + ArrivalCityCode + "&tripType=0&channelId=1&_=" + temp;
            string postpara = "";
            s = BaseController.GetPage(url, postpara, m_cookies, true, "UTF-8");
            int ine1 = 0;

            JsonSerializerSettings js = new JsonSerializerSettings();
            js.NullValueHandling = NullValueHandling.Include;
            js.ContractResolver = new CamelCasePropertyNamesContractResolver();

            try
            {

                if (s.StartsWith("Err") || s.Contains("频率太快"))
                {
                    throw new ArgumentException(s);
                }

                RootMF flights = JsonConvert.DeserializeObject<RootMF>(s, js);

                if (flights.ResultCode != "00")
                {
                    return "Err 获取航线数据错误!";
                }

                for (int i = 0; i < flights.FlightInfos1.Length; i++)
                {
                    url = "https://et.xiamenair.com/xiamenair/book/findMore.json?r=" + Rantxt + "&org=" + flights.OrgCity + "&dst=" + flights.DstCity + "&date=" + flights.TakeoffDate + "&tripType=" + flights.TripType + "&curTrip=0&fltNo=" + flights.FlightInfos1[i].Airline + flights.FlightInfos1[i].FltNo + "&update=aq20150421";


                    var R = new R();
                    R.org = flights.OrgCity;
                    R.dst = flights.DstCity;
                    R.takeoffDate = flights.TakeoffDate;
                    R.returnDate = flights.ReturnDate;
                    R.takeoffTime = flights.FlightInfos1[i].TakeoffTime;
                    R.arrivalTime = flights.FlightInfos1[i].ArrivalTime;
                    R.tripType = flights.TripType;
                    R.stop = flights.FlightInfos1[i].Stop;
                    R.equipment = flights.FlightInfos1[i].Equipment;
                    R.fltNo = flights.FlightInfos1[i].FltNo;
                    R.airline = flights.FlightInfos1[i].Airline;
                    R.arriveAd = flights.FlightInfos1[i].ArriveAd;
                    R.classes = flights.FlightInfos1[i].Classes;
                    R.codeShareList = flights.FlightInfos1[i].CodeShareList;
                    R.curTrip = 0;
                    R.channelId = 1;
                    if (flights.FlightInfos1[i].CBrand != null)
                    {
                        R.bottomCabin = flights.FlightInfos1[i].CBrand.Cabin;
                    }

                    postpara = JsonConvert.SerializeObject(R);

                    ts = DateTime.Now - new DateTime(1970, 1, 1);
                    string temp1 = ts.TotalMilliseconds.ToString().Substring(0, ts.TotalMilliseconds.ToString().IndexOf('.'));

                    string refer = "https://et.xiamenair.com/xiamenair/book/findFlights.action?lang=zh&tripType=0&queryFlightInfo=" + DepartureCityCode + "," + ArrivalCityCode + "," + datestr + "";

                    s = BaseController.GetPage(url, postpara, m_cookies, true, "UTF-8", refer, "et.xiamenair.com", "https://et.xiamenair.com", "application/json");

                    if (s.StartsWith("Err") || s.Contains("频率太快") || s.Contains("错误信息"))
                    {
                        continue;
                    }

                    string 价格2 = "null";
                    string 税费2 = "null";

                    string 航班号1 = flights.FlightInfos1[i].FltNo;
                    string 起飞时间1 = flights.FlightInfos1[i].TakeoffTime;
                    string 到达时间1 = flights.FlightInfos1[i].ArrivalTime;

                    string 航班号2 = "";
                    string 舱位2 = "";
                    string 舱位余量2 = "";
                    string 出发2 = "";
                    string 到达2 = "";
                    string 起飞时间2 = "";
                    string 到达时间2 = "";

                    RootMfInfo mfinfo = JsonConvert.DeserializeObject<RootMfInfo>(s, js);
                    for (int j = 0; j < mfinfo.BrandList.Length; j++)
                    {
                        string 舱位1 = mfinfo.BrandList[j].Cabin;
                        string 舱位余量1 = mfinfo.BrandList[j].Seats;
                        if (舱位余量1 == "")
                        {
                            舱位余量1 = "A";
                        }
                        string 出发1 = flights.FlightInfos1[i].Org;
                        string 到达1 = flights.FlightInfos1[i].Dst;
                        string 价格1 = mfinfo.BrandList[j].Price;
                        string 税费1 = (flights.FlightInfos1[i].AirportTax[0] + flights.FlightInfos1[i].FuelTax[0]).ToString();

                        SearchResult Result = new SearchResult();
                        Result.AirLine = 航司;
                        Result.AirLineName = "厦门航空";
                        Result.AirportPrice = 税费1;
                        Result.ArrivalCityCode = ArrivalCityCode;
                        Result.ArrivalTime = DateTime.Parse(到达时间1);
                        Result.BookUrl = "https://www.xiamenair.com/zh-cn/";
                        Result.ClassCode = 舱位1;
                        Result.DepartureCityCode = DepartureCityCode;
                        Result.DepartureTime = DateTime.Parse(起飞时间1);
                        Result.FlightNo = 航班号1;
                        Result.IsInter = IsInter;
                        Result.Storage = 舱位余量1;
                        Result.TicketPrice = float.Parse(价格1);
                        Result.DepDateTime = datestr;
                        Result.UpdateBatch = 更新批次;
                        Result.UpdateTime = DateTime.Now;
                        foreach (var item in Dic.cityArray)
                        {
                            foreach (var item1 in item.tabdata)
                            {
                                foreach (var item2 in item1.dd)
                                {
                                    if (item2.cityCode == ArrivalCityCode)
                                    {
                                        Result.ArrivalCity = item2.cityName;
                                        break;
                                    }
                                    else if (item2.cityCode == DepartureCityCode)
                                    {
                                        Result.DepartureCity = item2.cityName;
                                        break;
                                    }
                                }
                                if (!string.IsNullOrEmpty(Result.ArrivalCity) && !string.IsNullOrEmpty(Result.DepartureCity))
                                {
                                    break;
                                }
                            }
                            if (!string.IsNullOrEmpty(Result.ArrivalCity) && !string.IsNullOrEmpty(Result.DepartureCity))
                            {
                                break;
                            }
                        }
                        ResultService.SvcAdapter.AddObject(Result);

                        icount++;

                    }
                    string liststr = "[" + DateTime.Now.ToString() + "] 机票//" + 航司 + "//" + DepartureCityCode + "//" + ArrivalCityCode + "//" + datestr + "//采集到" + (flights.FlightInfos1.Length).ToString() + "个航班，共" + icount.ToString() + "条数据";
                    listBox1.Invoke(new InvokeDelegate(InvokeList), liststr);
                    var tempinfo = ResultService.SvcAdapter.GetList(a => a.AirLine == 航司 && a.DepartureCityCode == DepartureCityCode && a.ArrivalCityCode == ArrivalCityCode && a.DepDateTime == datestr && a.UpdateBatch != 更新批次);
                    if (tempinfo != null)
                    {
                        ResultService.SvcAdapter.DeleteObject(tempinfo);
                    }

                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(5000);
            }
            return s;
        }

        private string GetZH(string DepartureCityCode, string ArrivalCityCode, string IsInter, string datestr, int Interval)
        {
            CookieCollection m_cookies = new CookieCollection();
            int icount = 0;
            double r = ran.NextDouble();
            string 航司 = "ZH";
            double 更新批次 = r;

            string url = "http://www.shenzhenair.com/";
            string s = BaseController.GetPage(url, "", m_cookies, true, "UTF-8");

            //时间戳
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1);
            string temp = ts.TotalMilliseconds.ToString().Substring(0, ts.TotalMilliseconds.ToString().IndexOf('.'));

            url = "http://www.shenzhenair.com/szair_B2C/flightsearch.action?hcType=DC&orgCity=&orgCityCode=" + DepartureCityCode + "&dstCity=&dstCityCode=" + ArrivalCityCode + "&orgDate=" + datestr + "&dstDate=";
            string postpara = "";
            s = BaseController.GetPage(url, postpara, m_cookies, true, "UTF-8");
            int ine1 = 0;

            JsonSerializerSettings js = new JsonSerializerSettings();
            js.NullValueHandling = NullValueHandling.Include;
            js.ContractResolver = new CamelCasePropertyNamesContractResolver();

            try
            {

                if (s.StartsWith("Err") || s.Contains("频率太快"))
                {
                    throw new ArgumentException(s);
                }

                url = "http://www.shenzhenair.com/szair_B2C/flightSearch.action";

                postpara = "condition.orgCityCode=" + DepartureCityCode + "&condition.dstCityCode=" + ArrivalCityCode + "&condition.hcType=DC&condition.orgDate=" + datestr + "";

                string refer = "http://www.shenzhenair.com/szair_B2C/flightsearch.action?hcType=DC&orgCity=&orgCityCode=" + DepartureCityCode + "&dstCity=&dstCityCode=" + ArrivalCityCode + "&orgDate=" + datestr + "&dstDate=";

                s = BaseController.GetPage(url, postpara, m_cookies, true, "UTF-8", refer, "www.shenzhenair.com", "http://www.shenzhenair.com", "application/json");

                if (s.StartsWith("Err") || s.Contains("频率太快") || s.Contains("错误信息"))
                {
                    return "Err 提取数据出现访问限制!";
                }


                RootZH flights = JsonConvert.DeserializeObject<RootZH>(s, js);

                if (flights.FlightSearchResult != null)
                {
                    for (int i = 0; i < flights.FlightSearchResult.FlightInfoList.Length; i++)
                    {

                        string 价格2 = "null";
                        string 税费2 = "null";

                        string 航班号1 = flights.FlightSearchResult.FlightInfoList[i].FlightNo;
                        string 起飞时间1 = flights.FlightSearchResult.FlightInfoList[i].OrgDate + " " + flights.FlightSearchResult.FlightInfoList[i].OrgTime;
                        string 到达时间1 = flights.FlightSearchResult.FlightInfoList[i].DstDate + " " + flights.FlightSearchResult.FlightInfoList[i].DstTime;

                        string 航班号2 = "";
                        string 舱位2 = "";
                        string 舱位余量2 = "";
                        string 出发2 = "";
                        string 到达2 = "";
                        string 起飞时间2 = "";
                        string 到达时间2 = "";

                        for (int j = 0; j < flights.FlightSearchResult.FlightInfoList[i].ClassInfoList.Length; j++)
                        {
                            string 舱位1 = flights.FlightSearchResult.FlightInfoList[i].ClassInfoList[j].ClassCode;
                            string 舱位余量1 = flights.FlightSearchResult.FlightInfoList[i].ClassInfoList[j].Storage;
                            if (舱位余量1 == "")
                            {
                                舱位余量1 = "A";
                            }
                            string 出发1 = flights.FlightSearchResult.FlightInfoList[i].OrgCity;
                            string 到达1 = flights.FlightSearchResult.FlightInfoList[i].DstCity;
                            string 价格1 = flights.FlightSearchResult.FlightInfoList[i].ClassInfoList[j].TicketPrice.ToString();
                            string 税费1 = flights.FlightSearchResult.FlightInfoList[i].AirportPrice;
                            SearchResult Result = new SearchResult();
                            Result.AirLine = 航司;
                            Result.AirLineName = "深圳航空";
                            Result.AirportPrice = 税费1;
                            Result.ArrivalCityCode = ArrivalCityCode;
                            Result.ArrivalTime = DateTime.Parse(到达时间1);
                            Result.BookUrl = "http://www.shenzhenair.com/";
                            Result.ClassCode = 舱位1;
                            Result.DepartureCityCode = DepartureCityCode;
                            Result.DepartureTime = DateTime.Parse(起飞时间1);
                            Result.FlightNo = 航班号1;
                            Result.IsInter = IsInter;
                            Result.Storage = 舱位余量1;
                            Result.TicketPrice = float.Parse(价格1);
                            Result.DepDateTime = datestr;
                            Result.UpdateBatch = 更新批次;
                            Result.UpdateTime = DateTime.Now;
                            foreach (var item in Dic.cityArray)
                            {
                                foreach (var item1 in item.tabdata)
                                {
                                    foreach (var item2 in item1.dd)
                                    {
                                        if (item2.cityCode == ArrivalCityCode)
                                        {
                                            Result.ArrivalCity = item2.cityName;
                                            break;
                                        }
                                        else if (item2.cityCode == DepartureCityCode)
                                        {
                                            Result.DepartureCity = item2.cityName;
                                            break;
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(Result.ArrivalCity) && !string.IsNullOrEmpty(Result.DepartureCity))
                                    {
                                        break;
                                    }
                                }
                                if (!string.IsNullOrEmpty(Result.ArrivalCity) && !string.IsNullOrEmpty(Result.DepartureCity))
                                {
                                    break;
                                }
                            }
                            ResultService.SvcAdapter.AddObject(Result);
                            icount++;

                        }
                        string liststr = "[" + DateTime.Now.ToString() + "] 机票//" + 航司 + "//" + DepartureCityCode + "//" + ArrivalCityCode + "//" + datestr + "//采集到" + (flights.FlightSearchResult.FlightInfoList.Length).ToString() + "个航班，共" + icount.ToString() + "条数据";
                        listBox1.Invoke(new InvokeDelegate(InvokeList), liststr);
                        var tempinfo = ResultService.SvcAdapter.GetList(a => a.AirLine == 航司 && a.DepartureCityCode == DepartureCityCode && a.ArrivalCityCode == ArrivalCityCode && a.DepDateTime == datestr && a.UpdateBatch != 更新批次);
                        if (tempinfo != null)
                        {
                            ResultService.SvcAdapter.DeleteObject(tempinfo);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(5000);
            }
            return s;
        }
        /// <summary>
        /// 新增任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string Dep = DepCode.Text.Trim();
            string Arr = ArrCode.Text.Trim();
            string In = Interval.Text.Trim();
            if (string.IsNullOrEmpty(Dep))
            {
                MessageBox.Show("出发机场不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(Arr))
            {
                MessageBox.Show("到达机场不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(In))
            {
                MessageBox.Show("采集间隔不能为空!");
                return;
            }
            string[] strList = AirLineStr.Split(',');
            for (int i = 0; i < strList.Length; i++)
            {
                SearchLine line = new SearchLine();
                line.Days = 7;
                line.ArrivalCityCode = Arr;
                line.DepartureCityCode = Dep;
                line.Interval = int.Parse(In);
                line.IsAccessTask = false;
                line.LastDay = 0;
                line.AirLine = strList[i];
                LineService.SvcAdapter.AddObject(line);
            }
            MessageBox.Show("成功");
        }
        /// <summary>
        /// 刷新任务列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            LoadGridView();
        }
    }
}
