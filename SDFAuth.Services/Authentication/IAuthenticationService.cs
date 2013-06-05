using DB.SDFAuth;

namespace SDFAuth.Services.Authentication
{
    /// <summary>
    /// Authentication service interface
    /// </summary>
    public partial interface IAuthenticationService 
    {
        void SignIn(user customer, bool createPersistentCookie);
        void SignOut();
        user GetAuthenticatedUser();
    }
}