using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTradingProject.MODEL.Entities
{
    public class PriceCalculation : BaseEntity
    {
        public int MinimumWeight { get; set; }
        public int MaximumWeight { get; set; }
        public decimal Price { get; set; }
    }
}
