﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SDFAuthV2.Framework;
using SDFAuthV2.Models;

namespace SDFAuthV2.Controllers
{
    public partial class ErrorController : BaseController
    {

        public ActionResult Index()
        {
            var model = new ErrorModel();
            var httpException = RouteData.Values["httpException"] as HttpException;

            var httpCode = (httpException == null) ? 500 : httpException.GetHttpCode();

            switch (httpCode)
            {
                case 403:
                    Response.StatusCode = 403;
                    model.Heading = "Forbidden";
                    model.Message = "You aren't authorised to access this page.";
                    break;
                case 404:
                    Response.StatusCode = 404;
                    model.Heading = "Page not found";
                    model.Message = "We couldn't find the page you requested.";
                    break;
                case 500:
                default:
                    Response.StatusCode = 500;
                    model.Heading = "Error";
                    model.Message = "Sorry, something went wrong.  It's been logged.";
                    break;
            }
            
            Response.TrySkipIisCustomErrors = true;

            return View(model);
        }
    }
}
