using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Autofac;
using Autofac.Tests.Integration.Mvc;
using SDF.Core.Infrastructure.DependencyManagement;


namespace SDF.Core.Infrastructure
{
    public class SDFEngine 
    {
      
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Initialize()
        {
            /*bool databaseInstalled = DataSettingsHelper.DatabaseIsInstalled();
            if (databaseInstalled)
            {
                //startup tasks
                RunStartupTasks();
            }*/
            //startup tasks
            //RunStartupTasks();

            var builder = new ContainerBuilder();
            builder.RegisterType<WebAppTypeFinder>().As<ITypeFinder>().SingleInstance();
           _container =  builder.Build();
            if (HttpContext.Current == null)
            {
                _applicationContainer = new StubLifetimeScopeProvider(_container).GetLifetimeScope(null);
            }
            else
            {
                _applicationContainer = _container;
            }
            var typeFinder =  _container.Resolve<ITypeFinder>();
            UpdateContainer(x =>
            {
                var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
                var drInstances = new List<IDependencyRegistrar>();
                foreach (var drType in drTypes)
                    drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
                //sort
                drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
                foreach (var dependencyRegistrar in drInstances)
                    dependencyRegistrar.Register(x, typeFinder);
            });

        }

        private static IContainer _container;
        private static ILifetimeScope _applicationContainer;
        //private static IContainer Container {
        //    get
        //    {
        //        if (_container == null)
        //        {
        //            Initialize();
        //        }
        //        return _container;
        //    }
        //}

        public static ILifetimeScope Container
        {
            get { return _applicationContainer; }
        }

        public static void UpdateContainer(Action<ContainerBuilder> action)
        {
            var builder = new ContainerBuilder();
            action.Invoke(builder);
            builder.Update(_container);


        }
    }
}
