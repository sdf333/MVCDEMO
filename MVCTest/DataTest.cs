using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ServiceModel;
using Autofac.Integration.Mvc;
using Contract;
using DB.SDFAuth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nop.Services.Blogs;
using SDF.Core.Infrastructure;
using Autofac;
using SDFAuth.Data;
using SDFAuthV2.Controllers;

namespace CoreTest
{
    [TestClass]
    public class DataTest
    {
        protected SDFAuthEntities context;

        [TestInitialize()]
        public void Initialize()
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            context = new SDFAuthEntities();
            context.Database.Delete();
            context.Database.Create();
            //SDFEngine.Initialize();
        }

        protected string GetTestDbName()
        {
            string testDbName = "Data Source=" + (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + @"\\Data.Tests.Db.sdf;Persist Security Info=False";
            return testDbName;
        }        

        [TestMethod]
        public void Test1()
        {
            var repository = SDFEngine.Container.Resolve<IRepository<user>>();
            var count = repository.GetCount();
            Assert.IsTrue(count >= 0);
        }

    }
}
