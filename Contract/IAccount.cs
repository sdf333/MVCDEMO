using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using DB.SDFAuth;

namespace Contract
{
    [ServiceContract]
    public interface IAccount
    {
        [OperationContract]
        bool ExistUser(string user);

        [OperationContract]
        List<user> GetUserList();
    }
}
