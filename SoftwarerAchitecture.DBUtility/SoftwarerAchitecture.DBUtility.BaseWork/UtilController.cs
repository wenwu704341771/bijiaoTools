using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace SoftwarerAchitecture.DBUtility.BaseWork
{

    public class UtilController : CommonController
    {
        public static string GetIP()
        {
            string url = "http://ip.chinaz.com/getip.aspx";
            string s = GetPage(url, "", null, false);
            if (s.Length > 20)
            {
                string ip = s.Substring(s.IndexOf("ip") + 4, s.IndexOf(',') - 6);
                return ip;
            }
            else
            {
                url = "http://1212.ip138.com/ic.asp";
                s = GetPage(url, "", null, false);
                int ine1 = 0;
                string ip = CutString(1, s, "[", "]", ref ine1);
                return ip;
            }
        }
    }


}
