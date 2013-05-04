//using System.Web.Mvc;
//using HtmlAgilityPack;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using RazorGenerator.Testing;
//using SDFAuth2.Models;
//using SDFAuthV2.Views.Account;
//using WatiN.Core;

//namespace MVCTest
//{
//    [TestClass]
//    public class ViewTest
//    {
//        [TestMethod]
//        public void ViewTest1()
//        {
//            //TODO run error
//            var model = new LoginModel();
//            var view = new Login();
//            view.ViewBag.Title = "Login";
//            var viewContext = new ViewContext();
//            viewContext.ViewData =new ViewDataDictionary<LoginModel>();
//            view.ViewContext = viewContext;
            
//            HtmlDocument doc = view.RenderAsHtml(model);
//            HtmlNode node = doc.DocumentNode.Element("title");
//            Assert.AreEqual("Login", node.InnerHtml.Trim());
//        }

//        [TestMethod]
//        public void ViewTest2()
//        {
//            using (IE ie = new IE("http://localhost:4224/"))
//            {

//                Element element = ie.Element(Find.ByElement(_ => _.TagName =="title"));
//                string resultStats = element.Text;
//                Assert.AreEqual(resultStats, "SimpleAdmin - Login to CMS");
//            }
//        }
//    }
//}
