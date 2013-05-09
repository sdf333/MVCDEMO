using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nop.Core.Fakes;
using Nop.Services.Blogs;
using SDF.Core;
using SDF.Core.Infrastructure;
using Autofac;
using SDF.MVC.ActionResult;
using SDF.MVC.Filters;
using System.Linq;
using SDFAuthV2.Controllers;

namespace CoreTest
{
    [TestClass]
    public class PagedResultTest
    {
        [TestInitialize()]
        public void Initialize()
        {
            SDFEngine.Initialize();
        }

        [TestMethod]
        public void PageTest1()
        {
            var controller = SDFEngine.Container.Resolve<GridController>();
            var result = controller.List(1, 10);
            

           // var result2 = result.MapperTo(_ => new {id = _.CityID, ZipCode = _.ZipCode});
            
        }
    }
}
