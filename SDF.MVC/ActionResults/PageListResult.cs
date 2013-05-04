using System.Web.Mvc;
using SDF.Core;
using SDF.MVC;

namespace Ebuy
{
    public class PageListResult : ActionResult
    {
        private PagedList<object> list;
        public PageListResult(PagedList<object> _list)
        {
            list = _list;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            //var model = new JqGridModel();
            //model.PageIndex = list.PageIndex;
            //model.TotalPages = list.TotalPages;
            //model.TotalCount = list.TotalCount;
            //model.List = list.Select(_ => new { id = _.CityID, ZipCode = _.ZipCode });

            //return this.JsonNet(model, JsonRequestBehavior.AllowGet);
        }
    }
}