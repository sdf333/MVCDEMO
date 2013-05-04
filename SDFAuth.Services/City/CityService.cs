using System;
using System.Collections.Generic;
using System.Linq;
using DB.SDFAuth;
using SDF.Core;
using SDF.Core.Caching;
using SDFAuth;
using SDFAuth.Data;
using SDFAuth.Services;

namespace Nop.Services.Blogs
{
    /// <summary>
    /// Blog service
    /// </summary>
    public class CityService : BaseService, ICityService
    {

        private readonly IRepository<S_City> _S_Cityrepository;


        public CityService(IRepository<S_City> S_Cityrepository)
        {
            _S_Cityrepository = S_Cityrepository;
        }

        public List<S_Province> GetProvincere()
        {
            throw new NotImplementedException();
        }

        public PagedList<S_City> GetCityList(int pageIndex, int pageSize)
        {
            var query = _S_Cityrepository.Table.OrderBy(_ => _.CityID);

            return new PagedList<S_City>(query, pageIndex, pageSize);
        }
    }

}