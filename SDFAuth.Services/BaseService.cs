using System;
using System.Collections.Generic;
using System.Linq;
using SDF.Core.Caching;
using SDF.Core;

namespace SDFAuth.Services{

    public abstract class BaseService
    {
        public ICacheManager CacheManager { get; set; }
    }

}
