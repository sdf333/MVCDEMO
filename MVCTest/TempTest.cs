using System;
using System.Collections.Generic;
using System.ServiceModel;
using Autofac.Integration.Mvc;
using Contract;
using DB.SDFAuth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nop.Services.Blogs;
using SDF.Core;
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
            var controller = SDFEngine.Container.Resolve<GridController>();
            var rtn = controller.List(1,10);
            object o = rtn.Data;
            var o2 = o as IPagedList<S_City>;
            
            Assert.IsNull(o2);
        }

       
    }
}
