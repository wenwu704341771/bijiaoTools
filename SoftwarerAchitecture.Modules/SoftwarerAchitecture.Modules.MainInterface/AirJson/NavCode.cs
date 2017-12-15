using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwarerAchitecture.Modules.MainInterface
{
    public class DdItem
    {
        /// <summary>
        /// 北京
        /// </summary>
        public string cityName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cityCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tce_rule_count { get; set; }
    }

    public class TabdataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string dt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DdItem> dd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tce_rule_count { get; set; }
    }

    public class CityArrayItem
    {
        /// <summary>
        /// 热门城市
        /// </summary>
        public string tabname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TabdataItem> tabdata { get; set; }
    }

    public class NavCode
    {
        /// <summary>
        /// 
        /// </summary>
        public List<CityArrayItem> cityArray { get; set; }
    }
}
