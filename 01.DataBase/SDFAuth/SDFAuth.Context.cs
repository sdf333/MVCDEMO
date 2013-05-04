﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB.SDFAuth
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using DataBase;
    using System.Configuration;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    
    public partial class SDFAuthEntities : BaseDbContext
    {
        public SDFAuthEntities()
            : base(Conn)
        {
    		Database.SetInitializer<SDFAuthEntities>(null);
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    	private static ConnectionStringSettings Conn
        {
            get { return ConfigurationManager.ConnectionStrings["SDFAuth"]; }
        }
        public DbSet<application> applications { get; set; }
        public DbSet<S_City> S_City { get; set; }
        public DbSet<S_District> S_District { get; set; }
        public DbSet<S_Province> S_Province { get; set; }
        public DbSet<UserCity> UserCity { get; set; }
        public DbSet<user> user { get; set; }
    
        public virtual ObjectResult<user> GetUserList(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<user>("GetUserList", userIdParameter);
        }
    
        public virtual ObjectResult<user> GetUserList(Nullable<int> userId, MergeOption mergeOption)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<user>("GetUserList", mergeOption, userIdParameter);
        }
    }
}
