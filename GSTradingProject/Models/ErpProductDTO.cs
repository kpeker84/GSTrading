using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSTradingProject.Models
{
    public class ErpProductDTO
    {
        [JsonProperty("@odata.etag")]
        public string etag { get; set; }
        public string id { get; set; }
        public string number { get; set; }
        public string displayName { get; set; }
        public string type { get; set; }
        public string itemCategoryId { get; set; }
        public string itemCategoryCode { get; set; }
        public string blocked { get; set; }
        public string gtin { get; set; }
        public int inventory { get; set; }
        public int unitPrice { get; set; }
        public int priceIncludexTax { get; set; }
        public int unitCost { get; set; }
        public string taxGroupId { get; set; }
        public string taxGroupCode { get; set; }
        public string baseUnitOfMeasureId { get; set; }
        public string baseUnitOfMeasureCode { get; set; }
        public string lastModifiedDateTime { get; set; }
    }
}