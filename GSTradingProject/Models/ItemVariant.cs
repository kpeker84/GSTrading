using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSTradingProject.Models
{
    public class ItemVariant
    {
        [JsonProperty("@odata.etag")]
        public string etag { get; set; }
        public string id { get; set; }
        public string itemId { get; set; }
        public string itemNumber { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }
}