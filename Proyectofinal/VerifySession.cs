using Proyectofinal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyectofinal
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = Convert.ToString(HttpContext.Current.Session["Usuario"]);

            if (user == null || user == "")
            {
                if (filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/Login");
                }
            }
            else
            {
                if (filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}