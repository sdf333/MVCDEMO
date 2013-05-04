using System;
using System.Collections.Generic;
using System.Linq;
using DB.SDFAuth;
using SDF.Core.Caching;
using SDFAuth.Data;
using SDFAuth.Services;

namespace Nop.Services.Blogs
{
    /// <summary>
    /// Blog service
    /// </summary>
    public class UserCityService : BaseService, IUserCityService
    {
        private readonly IRepository<UserCity> _repository;
        private const string UserCityKey = "UserCity_KEY";

        public UserCityService(IRepository<UserCity> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 获取省列表
        /// </summary>
        /// <returns></returns>
        public UserCity GetItem()
        {
            var i = GeCacheData().SingleOrDefault();
            return i;
        }

        private IEnumerable<UserCity> GeCacheData()
        {
            var key = string.Format(UserCityKey);
            var list = CacheManager.Get(key, () => _repository.Table.ToList());
            return list;
        }
        
        public  void Add(UserCity c)
        {
            _repository.Add(c);
            CacheManager.Remove(UserCityKey);
        }

        public void Update(UserCity c)
        {
            _repository.Update(c);
            CacheManager.Remove(UserCityKey);
        }
    }
}