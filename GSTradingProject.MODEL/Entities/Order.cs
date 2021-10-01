using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTradingProject.MODEL.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerID { get; set; }

        //relations begin

        public virtual Customer Customer { get; set; }
        public virtual List<ProductOrder> ProductOrders { get; set; }
    }
}
