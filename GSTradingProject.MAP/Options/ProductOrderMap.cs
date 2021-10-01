using GSTradingProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTradingProject.MAP.Options
{
    public class ProductOrderMap : BaseMap<ProductOrder>
    {
        public ProductOrderMap()
        {
            Ignore(x => x.ID);
            HasKey(x => new
            {
                x.ProductID,
                x.OrderID
            });
        }
    }
}
