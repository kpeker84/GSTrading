using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSTradingProject.Models
{
    public class ErpProductImageModel
    {
        [JsonProperty("@odata.context")]
        public string context { get; set; }
        [JsonProperty("@odata.etag")]
        public string etag { get; set; }
        public string id { get; set; }
        public string parentType { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string contentType { get; set; }
        [JsonProperty("pictureContent@odata.mediaEditLink")]
        public string mediaEditLink { get; set; }
        [JsonProperty("pictureContent@odata.mediaReadLink")]
        public string mediaReadLink { get; set; }
    }
}