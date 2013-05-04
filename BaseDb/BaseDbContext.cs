using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Configuration;
using System.Data.Entity.Infrastructure;
//using EFTracingProvider;
//using EFProviderWrapperToolkit;
using System.Data.Common;

namespace DataBase
{
    public abstract class BaseDbContext : DbContext
    {
        private static readonly Dictionary<ConnectionStringSettings, string> connMap =
            new Dictionary<ConnectionStringSettings, string>();

        protected BaseDbContext(ConnectionStringSettings connsetting)
            : base(GetEntityConnString(connsetting))
        {

        }

        protected static string GetEntityConnString(ConnectionStringSettings connsetting)
        {
            if (connMap.ContainsKey(connsetting))
            {
                return connMap[connsetting];
            }

            var entityBuilder = new EntityConnectionStringBuilder
                                    {
                                        Metadata =
                                            string.Format(
                                                "res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl",
                                                connsetting.Name),
                                        ProviderConnectionString =
                                            connsetting.ConnectionString,
                                        Provider = connsetting.ProviderName
                                    };
            var connstr = entityBuilder.ToString();
            connMap.Add(connsetting, connstr);
            return connstr;
        }

        public string CreateDatabaseScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }
    }
}
