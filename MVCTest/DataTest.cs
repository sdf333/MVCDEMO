using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ServiceModel;
using Autofac.Integration.Mvc;
using Contract;
using DB.SDFAuth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nop.Services.Blogs;
using SDF.Core.Infrastructure;
using Autofac;
using SDFAuth.Data;
using SDFAuthV2.Controllers;

namespace CoreTest
{
    [TestClass]
    public class DataTest
    {

        [TestInitialize()]
        public void Initialize()
        {
            SDFEngine.Initialize();
            var context = SDFEngine.Container.Resolve<SDFAuthEntities>();
            context.Database.Delete();
            context.Database.Create();
        }

        [TestMethod]
        public void Test1()
        {
            var repository = SDFEngine.Container.Resolve<IRepository<user>>();
            var count = repository.GetCount();
            Assert.IsTrue(count >= 0);
        }

    }
}
