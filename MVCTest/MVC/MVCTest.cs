using System;
using Autofac.Integration.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nop.Services.Blogs;
using SDF.Core.Infrastructure;
using Autofac;
using SDFAuthV2.Controllers;
using SDFAuthV2.Framework;

namespace CoreTest
{
    [TestClass]
    public class MVCTest
    {
        [TestInitialize()]
        public void Initialize()
        {
            SDFEngine.Initialize();
            
        }

        [TestMethod]
        public void TestController()
        {
            Assert.IsNotNull(typeof (DependencyRegistrar));
            var accountController = SDFEngine.Container.Resolve<AccountController>();
            var result = accountController.Exists("sdf333");
        }
        
    }
}
