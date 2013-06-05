using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using SDF.Core.Infrastructure;
using SDFAuthV2.Framework;

namespace SDFAuthV2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //autofac说可以用builder.RegisterFilterProvider()来注入filter的属性一般的filter确实可以，但是全局filter不行
            //必须先builder.RegisterType<MyAuthorizeAttribute>
            //filters.Add(SDFEngine.Container.Resolve<MyAuthorizeAttribute>());
            
            filters.Add(new HandleErrorAttribute());
            
        }
    }
}