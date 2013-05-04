using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Web;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Wcf;
using Contract;
using DataBase;
using SDF.Core.Caching;
using SDF.Core.Infrastructure;
using SDF.Core.Infrastructure.DependencyManagement;
using SDFAuth.Data;
using SDFAuth.Services;
using WcfService;


//using SDF.Core.Plugins;
//using SDF.Data;

namespace Nop.Web.Framework
{
    public class WCFDependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            
            var contextList = typeFinder.FindClassesOfType<BaseDbContext>(true);
            foreach (var type in contextList)
            {
                var dbname = type.Name.Replace("Entities","");
                if (ConfigurationManager.ConnectionStrings[dbname] == null)
                {
                    continue;
                    
                }
                RegisterDB(builder, type, typeFinder);
            }
        
            //cache manager
            builder.RegisterType<CacheManager>().As<ICacheManager>().Named<ICacheManager>("sdf_cache_static").SingleInstance();

            var services = typeFinder.FindClassesOfType<BaseService>().ToList();
            services.ForEach(s => builder.RegisterType(s).AsImplementedInterfaces().PropertiesAutowired());


            builder.RegisterType<AccountService>().As<IAccount>();
            
        }

        private void RegisterDB(ContainerBuilder builder, Type type, ITypeFinder typeFinder)
        {
            var entityAssembly = Assembly.Load(type.Namespace);
            builder.RegisterType(type).Named<DbContext>(type.FullName);
            var a = new Assembly[] {entityAssembly};

            var typeList = typeFinder.FindClassesOfType<BaseEntity>(a,true);
            var tRepository = typeof(EfRepository<>);
            foreach (Type t in typeList)
            {
                var t2 = tRepository.MakeGenericType(t);
                builder.RegisterType(t2).AsImplementedInterfaces().WithParameter(ResolvedParameter.ForNamed<DbContext>(type.FullName));
            }
        }

        public int Order
        {
            get { return 0; }
        }
    }

}
