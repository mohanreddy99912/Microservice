using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Microservice.Filters
{
    public class DiagnosticActionFilter : ActionFilterAttribute
    {
        private const string Key = "__action_duration__";
        private string InvokerIp;
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Console.WriteLine("");
            Console.WriteLine(string.Format("==- @ {0}    {1} -=============== {2} =========",
                DateTime.Now.ToLongTimeString(), DateTime.Now.ToShortDateString(), actionContext.Request.RequestUri.PathAndQuery));

            Console.WriteLine("");
            var stopWatch = new Stopwatch();
            InvokerIp = GetIncomingInvokerIP(actionContext);
            actionContext.Request.Properties[Key] = stopWatch;

            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                foreach (var key in modelState.Keys)
                {
                    var state = modelState[key];
                    if (state.Errors.Any())
                    {
                        string er = state.Errors.First().ErrorMessage;
                        if (!string.IsNullOrEmpty(er))
                        {
                            Console.WriteLine(er);
                        }
                    }
                }
            }

            stopWatch.Start();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (!actionExecutedContext.Request.Properties.ContainsKey(Key))
            {
                return;
            }

            var stopWatch = actionExecutedContext.Request.Properties[Key] as Stopwatch;
            if (stopWatch != null)
            {
                stopWatch.Stop();

                Console.WriteLine("_____________________________________________________________");
                Console.WriteLine("");
                Console.WriteLine(string.Format("> [ Execution of {0}\n\n\r\t took {1}. called from IP: {2} ]", actionExecutedContext.Request.RequestUri.PathAndQuery, stopWatch.Elapsed, InvokerIp));
                Console.WriteLine("");
                Console.WriteLine("");
            }

        }

        private string GetIncomingInvokerIP(HttpActionContext actionContext)
        {
            if (actionContext.Request.Properties.ContainsKey("MS_OwinContext"))
            {
                OwinContext owinContext = (OwinContext)actionContext.Request.Properties["MS_OwinContext"];
                if (owinContext != null)
                {
                    return owinContext.Request.RemoteIpAddress;
                }
            }
            return string.Empty;
        }
    }

}
