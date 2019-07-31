using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorialTeacher.Action_Filters
{
    public class ActivityLog : ActionFilterAttribute, IExceptionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string message = "\n" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName +
                 " -> " + filterContext.ActionDescriptor.ActionName + " -> OnActionExecuting \t- " +
                 DateTime.Now.ToString() + "\n";
       
            logWrite(message);
        }

        public void logWrite(string message)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Data/Data.txt"), message);
        }

        public void OnException(ExceptionContext filterContext)
        {
            string message = filterContext.RouteData.Values["controller"].ToString() + " => "
                  + filterContext.RouteData.Values["action"].ToString() +
                  " => " + filterContext.Exception.Message + "\t -" + DateTime.Now.ToString() + "\n";
            logWrite(message);
        }
    }
}