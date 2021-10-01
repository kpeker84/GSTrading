using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSTradingProject.Models
{
    public class Cart
    {
        Dictionary<int, CartItem> _myCart;

        public Cart()
        {
            _myCart = new Dictionary<int, CartItem>();
        }

        public List<CartItem> Sepetim
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }

        public int TotalWeight
        {
            get
            {
                int deneme = 0;
                foreach (var item in Sepetim)
                {
                    deneme += item.StkWeight * item.Amount;
                }
                return deneme;
            }
        }

        public void AddToCart(CartItem item)
        {
            if (_myCart.ContainsKey(item.ID))
            {
                _myCart[item.ID].Amount += 1;
                return;
            }
            _myCart.Add(item.ID, item);

        }

        public void DeleteFromCart(int id)
        {
            _myCart.Remove(id);
        }

        public void ChangeAmount(int id, short amount)
        {
            _myCart[id].Amount = amount;
            if (amount == 0)
            {
                _myCart.Remove(id);
            }
        }

        public decimal? TotalPrice
        {
            get
            {
                return _myCart.Sum(x => x.Value.SubTotal);
            }

        }
    }
}