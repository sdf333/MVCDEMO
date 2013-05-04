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
using SDFAuth2.Models;
using SDFAuthV2.Framework;
using SDF.MVC.Extensions;

namespace SDFAuthV2.Controllers
{
    public class GridController : BaseController
    {
        private ICityService _cityService;

        public GridController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public ActionResult JdGrid()
        {
            return View();
        }

        //[GridFormats]
        public JsonNetResult List(int page, int rows)
        {
            var list = _cityService.GetCityList(page, rows);

            var model = new JqGridModel();
            model.PageIndex = list.PageIndex;
            model.TotalPages = list.TotalPages;
            model.TotalCount = list.TotalCount;
            model.List = list.Select(_ => new { id = _.CityID, ZipCode = _.ZipCode });
            
            return  this.JsonNet(model, JsonRequestBehavior.AllowGet);
        }

    }
}
