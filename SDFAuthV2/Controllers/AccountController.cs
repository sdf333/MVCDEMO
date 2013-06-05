using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Core;
using Nop.Services.Blogs;
using SDFAuth.Services.Authentication;
using SDFAuth2.Models;
using SDFAuthV2.Framework;

namespace SDFAuthV2.Controllers
{
    public class AccountController : BaseController
    {

        private readonly IUserService _userService;
        private  readonly IAuthenticationService _AuthenticationService;

           public AccountController(IUserService userService, IAuthenticationService AuthenticationService)
        {
            
            _userService = userService;
                        _AuthenticationService = AuthenticationService;
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

        [HttpGet] 
        public ActionResult Exists(string username)
        {
            var exists = _userService.ExistUser(username);
            return Json(!exists, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            _AuthenticationService.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
