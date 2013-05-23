using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Core;
using Nop.Services.Blogs;
using SDFAuth2.Models;
using SDFAuthV2.Framework;

namespace SDFAuthV2.Controllers
{
    public class AccountController : BaseController
    {

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            //var log = LogHelper.GetInstance();
            //log.Error(DateTime.Now.ToString() + "|| AccountController");
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                
            }
            return View();    
        }

        [HttpGet] // 只能用GET ！！！
        public ActionResult Exists(string username)
        {
            var exists = _userService.ExistUser(username);
            return Json(!exists, JsonRequestBehavior.AllowGet);
        }

    }
}
