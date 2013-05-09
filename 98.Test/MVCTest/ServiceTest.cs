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
    public class ServiceTest
    {
        [TestInitialize()]
        public void Initialize()
        {
            SDFEngine.Initialize();
        }

        [TestMethod]
        public void Test1()
        {
            var service = SDFEngine.Container.Resolve<IUserService>();
            var list = service.GetUserListSp();
            Assert.IsNotNull(list);
        }

    }
}
