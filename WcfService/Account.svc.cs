using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Contract;
using DB.SDFAuth;
using Nop.Services.Blogs;

namespace WcfService
{
    
    public class AccountService : IAccount
    {
        private readonly IUserService _userService;

        public AccountService(IUserService userService)
        {
            _userService = userService;
        }

        public bool ExistUser(string user)
        {
            return _userService.ExistUser("sdf333");
        }

        public List<user> GetUserList()
        {
            return _userService.GetUserList();
        }

    }
}
