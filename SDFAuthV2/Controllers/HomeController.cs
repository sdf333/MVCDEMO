using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DB.SDFAuth;
using Nop.Services.Blogs;
using SDF.Core;
using SDF.MVC;
using SDF.MVC.ActionResult;
using SDF.MVC.Filters;
using SDFAuth.Services.Authentication;
using SDFAuth2.Models;
using SDFAuthV2.Framework;
using SDF.MVC.Extensions;

namespace SDFAuthV2.Controllers
{
    public class HomeController : BaseController
    {
     
        public ActionResult Index()
        {
            throw new Exception("err");
            return View();
        }

       
    }
}
