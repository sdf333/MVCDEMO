using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using SDF.Core;
using SDF.Core.Infrastructure;
using SDFAuthV2.Controllers;
using log4net.Config;

namespace SDFAuthV2
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        protected void Application_Error()
        {
            if (HttpContext.Current == null)
            {
                // errors in Application_Start will end up here           

                return;
            }

            if (HttpContext.Current.IsCustomErrorEnabled)
            {
                return;
            }
            var exception = Server.GetLastError();

            
            var httpException = new HttpException(null, exception);
            if (httpException.GetHttpCode() == 404 && WebHelper.IsStaticResource(this.Request))
            {
                return;
            }

            //TODO: 记录Log（忽略404，403） 
            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Index");
            routeData.Values.Add("httpException", httpException);

            Server.ClearError();

            // Call target Controller and pass the routeData.
            //Ref nop&nblog
            IController errorController = SDFEngine.Container.Resolve<ErrorController>();

            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}