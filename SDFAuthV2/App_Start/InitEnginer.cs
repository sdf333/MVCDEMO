using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using SDF.Core.Infrastructure;
using StackExchange.Profiling;
using StackExchange.Profiling.MVCHelpers;
using Microsoft.Web.Infrastructure;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using StackExchange.Profiling.Data.EntityFramework;
//using StackExchange.Profiling.Data.Linq2Sql;

[assembly: WebActivator.PreApplicationStartMethod(
    typeof(SDFAuthV2.App_Start.InitEnginer), "PreStart")]

namespace SDFAuthV2.App_Start 
{
    public static class InitEnginer
    {
        public static void PreStart()
        {

            SDFEngine.Initialize();
        }
    }
}

