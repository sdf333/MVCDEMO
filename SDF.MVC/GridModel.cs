﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SDF.MVC
{
    public class JqGridModel
    {

        [JsonProperty(PropertyName = "page")]
        public int PageIndex { get; set; }
        [JsonProperty(PropertyName = "total")]
        public int TotalPages { get; set; }

        [JsonProperty(PropertyName = "records")]
        public int TotalCount { get; set; }

        [JsonProperty(PropertyName = "rows")]
        public IEnumerable<object> List { get; set; }

        //[JsonProperty(PropertyName = "userdata")]
        //public object Userdata { get; set; }

        //public class JqGridItem
        //{
        //    [JsonProperty(PropertyName = "id")]
        //    public string Id { get; set; }

        //    [JsonProperty(PropertyName = "cell")]
        //    public object Cell { get; set; }
        //}
    }
}
