using System;
using System.ServiceModel;
using Autofac.Integration.Mvc;
using Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nop.Services.Blogs;
using SDF.Core.Infrastructure;
using Autofac;
using SDFAuthV2.Controllers;

namespace CoreTest
{
    [TestClass]
    public class WcfClientTest
    {
        [TestInitialize()]
        public void Initialize()
        {
            SDFEngine.Initialize();
        }

        [TestMethod]
        public void WcfClientTest1()
        {
            using (ChannelFactory<IAccount> factory = new ChannelFactory<IAccount>(typeof(IAccount).FullName))
            {

                IAccount svc = factory.CreateChannel();
                var rtn = svc.ExistUser("sdf");
            }
        }

        [TestMethod]
        public void WcfClientTest2()
        {
            var service = SDFEngine.Container.Resolve<IAccount>();
            var result = service.ExistUser("sdf333");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WcfClientTest3()
        {
            var service = SDFEngine.Container.Resolve<IAccount>();
            var list = service.GetUserList();
            Assert.IsNotNull(list);

        }
    }
}
