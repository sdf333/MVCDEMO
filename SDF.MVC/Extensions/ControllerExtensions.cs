using System.Text;
using System.Web.Mvc;
using SDF.MVC.ActionResult;

namespace SDF.MVC.Extensions
{
    public static class ControllerExtensions
    {
        public static JsonNetResult JsonNet(this Controller controller, object data)
        {
            return JsonNet(controller,data, null /* contentType */, null /* contentEncoding */, JsonRequestBehavior.DenyGet);
        }

        public static JsonNetResult JsonNet(this Controller controller,object data, string contentType)
        {
            return JsonNet(controller, data, contentType, null /* contentEncoding */, JsonRequestBehavior.DenyGet);
        }

        public static JsonNetResult JsonNet(this Controller controller,object data, string contentType, Encoding contentEncoding)
        {
            return JsonNet(controller, data, contentType, contentEncoding, JsonRequestBehavior.DenyGet);
        }

        public static JsonNetResult JsonNet(this Controller controller,object data, JsonRequestBehavior behavior)
        {
            return JsonNet(controller, data, null /* contentType */, null /* contentEncoding */, behavior);
        }

        public static JsonNetResult JsonNet(this Controller controller,object data, string contentType, JsonRequestBehavior behavior)
        {
            return JsonNet(controller, data, contentType, null /* contentEncoding */, behavior);
        }

        public static JsonNetResult JsonNet(this Controller controller, object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}