using System;
using System.Collections.Generic;
using DB.SDFAuth;
using SDF.Core;
using SDFAuth;


namespace Nop.Services.Blogs
{

    public partial interface IUserService
    {

        List<user> GetUserList();
        List<user> GetUserListSp();

        bool Exist(user u);
        bool ExistUser(string user);
    }
}
