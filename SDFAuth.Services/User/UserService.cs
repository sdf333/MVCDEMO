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
    public class UserService : BaseService, IUserService
    {
        private const string APPLACATION_BY_ID_KEY = "SDF.user.id-{0}";
        private const string APPLACATION_PATTERN_KEY = "SDF.user.";

        private readonly IRepository<user> _userRepository;
        private readonly SDFAuthEntities _sdfDFAuthEntities;
        public UserService(IRepository<user> userRepository, SDFAuthEntities sdfDFAuthEntities)
        {
            _userRepository = userRepository;
            _sdfDFAuthEntities = sdfDFAuthEntities;
        }

        

        public List<user> GetUserList()
        {
            return _userRepository.Table.ToList();
        }

        public List<user> GetUserListSp()
        {
            return _sdfDFAuthEntities.GetUserList(1).ToList();
        }

        public bool Exist(user u1)
        {
            var count = _userRepository.Table.Count(u => u.userName == u1.userName
                                                         && u.password == u1.password);
            return count > 0;
        }

        public bool ExistUser(string user)
        {
            var count = _userRepository.Table.Count(u => u.userName == user);
            return count > 0;
        }

        public user GetUserInfo(string user)
        {
            return _userRepository.Table.SingleOrDefault(_ => _.userName == user);
        }
    }
}