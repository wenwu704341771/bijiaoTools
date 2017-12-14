using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace SoftwarerAchitecture.DBUtility.BaseWork
{
    public class CommonController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="returnxml">返回xml字符串</param>
        /// <param name="jrBehavior"></param>
        /// <returns></returns>
        public new ActionResult Json(object obj, bool returnxml = false, JsonRequestBehavior jrBehavior = JsonRequestBehavior.AllowGet)
        {
            Newtonsoft.Json.Converters.IsoDateTimeConverter jsonsettingconvert = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            jsonsettingconvert.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            Newtonsoft.Json.JsonSerializerSettings jsonsetting = new Newtonsoft.Json.JsonSerializerSettings();
            jsonsetting.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            jsonsetting.Converters.Add(jsonsettingconvert);

            var str = Newtonsoft.Json.JsonConvert.SerializeObject(obj, jsonsetting);
            return Content(str, "text/json", UTF8Encoding.UTF8);//base.Json(obj, jrBehavior);
        }
    }
}
