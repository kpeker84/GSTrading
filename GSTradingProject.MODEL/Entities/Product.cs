using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTradingProject.MODEL.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string ProductCode { get; set; }
        public string PZN { get; set; }
        public string THC { get; set; }
        public string CBD { get; set; }
        public string Genetik { get; set; }
        public string Darreichungsform { get; set; }
        public string ProductWeight { get; set; }

        //relations begin

        public virtual List<ProductOrder> ProductOrders { get; set; }
        public virtual List<Image> Images { get; set; }

    }
}
