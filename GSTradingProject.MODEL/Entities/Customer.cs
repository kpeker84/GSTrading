using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTradingProject.MODEL.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string Company { get; set; }

        //relations begin
        public virtual List<Order> Orders { get; set; }
    }
}
