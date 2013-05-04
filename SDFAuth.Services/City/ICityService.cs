using System;
using System.Collections.Generic;
using DB.SDFAuth;
using SDF.Core;
using SDFAuth;


namespace Nop.Services.Blogs
{

    public partial interface ICityService
    {

        List<S_Province> GetProvincere();

        PagedList<S_City> GetCityList(int pageIndex, int pageSize);
    }
}
