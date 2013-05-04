using System;
using System.Collections.Generic;
using System.ServiceModel;
using Autofac.Integration.Mvc;
using Contract;
using DB.SDFAuth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nop.Services.Blogs;
using SDF.Core;
using System.Linq;
using SDF.Core.Infrastructure;
using Autofac;
using SDFAuthV2.Controllers;

namespace CoreTest
{
    [TestClass]
    public class TempTest
    {
        [TestInitialize()]
        public void Initialize()
        {
            SDFEngine.Initialize();
        }

        [TestMethod]
        public void Test1()
        {
       
        }

       
    }
}
