using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.IO;
using SoftwarerAchitecture.Service.MainWebService;
using SoftwarerAchitecture.Models.DbMainInterface;
using Newtonsoft.Json;
using Util.Framework;
using SoftwarerAchitecture.DBUtility.BaseWork;
using SoftwarerAchitecture.Service.MainInterfaceService;
namespace SoftwarerAchitecture.Web.Controllers
{
    public class MainController : BaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string from_city, string to_city, string from_date)
        {
            DateTime StartTime = DateTime.Now;
            if (!string.IsNullOrEmpty(from_date))
            {
                StartTime = DateTime.Parse(from_date);
            }
            var list = new SearchResultService().SvcAdapter.GetList(a => a.DepartureCity == from_city && a.ArrivalCity == to_city && a.DepartureTime == StartTime).ToList();
            ViewBag.ModelList = list;
            ViewBag.from_city = from_city;
            ViewBag.to_city = to_city;
            ViewBag.from_date = from_date;
            return View();
        }
    }
}
