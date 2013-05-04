//using System;
//using System.Collections.Generic;
//using System.Web.Mvc;
//using SDF.Core.Infrastructure;
//using Autofac;

//namespace Nop.Web.Framework.Mvc
//{
//    public class SDFDependencyResolver : IDependencyResolver
//    {
//        public object GetService(Type serviceType)
//        {
//            return SDFEngine.Container.ResolveOptional(serviceType);
//        }

//        public IEnumerable<object> GetServices(Type serviceType)
//        {
//            var type = typeof(IEnumerable<>).MakeGenericType(serviceType);
//            return (IEnumerable<object>)SDFEngine.Container.Resolve(type);
//        }
//    }
//}
