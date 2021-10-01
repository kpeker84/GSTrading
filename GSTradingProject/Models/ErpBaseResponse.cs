using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSTradingProject.Models
{
    public class ErpBaseResponse<T>
    {
        [JsonProperty("@odata.context")]
        public string context { get; set; }
        public List<T> value { get; set; }
    }
}