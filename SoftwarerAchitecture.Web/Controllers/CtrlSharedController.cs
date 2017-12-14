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


namespace SoftwarerAchitecture.Web.Controllers
{
    public class CtrlSharedController : BaseController
    {
        public ActionResult TopBar()
        {
            return PartialView();
        }

    }
}
