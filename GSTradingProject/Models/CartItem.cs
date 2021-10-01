using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSTradingProject.Models
{
    public class CartItem
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public short Amount { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public int StkWeight { get; set; }

        public decimal SubTotal
        {
            get
            {

                return Price * Amount;

            }
        }

        public CartItem()
        {
            Amount++;
        }
    }
}