using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SoftwarerAchitecture.DBUtility.BaseWork
{
    public class LoginAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            //if (filterContext.HttpContext.Session != null &&
            //    filterContext.HttpContext.Session["loginusersession"] == null)
            //{
            //    filterContext.HttpContext.Response.StatusCode = 403;
            //    filterContext.Result = new RedirectResult("/Login/Index");
            //}
            //else
            //{
            //    if (filterContext.HttpContext.Session != null) filterContext.HttpContext.Session.Timeout = 20000;
            //}
        }
    }
}
