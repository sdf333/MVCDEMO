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
using SDF.Core.Infrastructure;
using Autofac;
using SDF.MVC.ActionResult;
using SDF.MVC.Filters;
using SDFAuthV2.Controllers;

namespace CoreTest
{
    [TestClass]
    public class PageTest
    {
        [TestInitialize()]
        public void Initialize()
        {
            SDFEngine.Initialize();
        }

        //[TestMethod]
        //public void PageTest1()
        //{
        //    var actionExecutedContext = new Mock<ActionExecutedContext>();
        //    var controller = SDFEngine.Container.Resolve<GridController>();
        //    actionExecutedContext.Setup(_ => _.HttpContext.Request["grid"]).Returns("jqgrid");

        //    actionExecutedContext.Object.Result = controller.List(1, 10);
        //    var gridFormatsattribute = new GridFormatsAttribute();
        //    gridFormatsattribute.OnActionExecuted(actionExecutedContext.Object);
        //}



        //[TestMethod]
        //public void PageTest1()
        //{
        //    var controller = SDFEngine.Container.Resolve<GridController>();
        //    var result = controller.List(1, 10);
        //    Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();     
        //    var response = new Mock<HttpResponseBase>();  
        //     var sb = new StringBuilder();
        //     var stringWriter = new StringWriter();

        //     response.Setup(x => x.Output).Returns(stringWriter);
        //    controllerContext.Setup(x => x.HttpContext.Response).Returns(response.Object);
        //    result.ExecuteResult(controllerContext.Object);
        //    var rtn = stringWriter.ToString();
        //}
    }
}
