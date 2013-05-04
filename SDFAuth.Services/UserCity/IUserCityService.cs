using System;
using System.Collections.Generic;
using DB.SDFAuth;
using SDF.Core;
using SDFAuth;


namespace Nop.Services.Blogs
{

    public partial interface IUserCityService
    {
        UserCity GetItem();

        void Add(UserCity c);

        void Update(UserCity c);
    }
}
