using System;
using System.Web.Mvc;
using SDFAuth.Services.Authentication;

namespace SDFAuthV2.Framework
{
    /// <summary>
    /// 写重授权机制
    /// </summary>
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public IAuthenticationService _authenticationService;

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            return true;
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            var user = _authenticationService.GetAuthenticatedUser();
            return user == null;
        }
    }
}