using GSTradingProject.BLL.Patterns.Repository.ConcRep;
using GSTradingProject.COMMON.Tools;
using GSTradingProject.MODEL.Entities;
using GSTradingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GSTradingProject.Controllers
{
    public class ShoppingController : Controller
    {
        private ProductRepository _pRep;
        private CustomerRepository _cRep;
        private OrderRepository _oRep;
        private ProductOrderRepository _poRep;
        private PriceCalculationRepository _pcRep;

        public ShoppingController()
        {
            _pRep = new ProductRepository();
            _cRep = new CustomerRepository();
            _oRep = new OrderRepository();
            _poRep = new ProductOrderRepository();
            _pcRep = new PriceCalculationRepository();
        }
        public bool AddToCart(int id, short amount)
        {
            try
            {
                Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;
                Product addedProduct = _pRep.Find(id);
                CartItem ci = new CartItem
                {
                    ID = addedProduct.ID,
                    Name = addedProduct.ProductName,
                    StkWeight = Convert.ToInt32(addedProduct.ProductWeight),
                    Price = addedProduct.Price * Convert.ToInt32(addedProduct.ProductWeight)

                };
                for (int i = 0; i < amount; i++)
                {
                    c.AddToCart(ci);
                }



                Session["scart"] = c;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        // GET: Shopping
        public ActionResult CartPage()
        {
            bool isCartContainsBeutel = false;
            bool isCartContainsOnlyBeutel = false;
            int totalAmount = 0;
            int totalWeight = 0;
            if (Session["scart"] != null)
            {

                Cart c = Session["scart"] as Cart;
                foreach (var item in c.Sepetim)
                {
                    if (c.Sepetim.Count == 1 && item.Name.ToLower() == "beutel")
                    {
                        if (item.Amount == 1)
                        {
                            isCartContainsBeutel = true;
                            isCartContainsOnlyBeutel = true;
                        }
                        if (item.Amount > 1)
                        {
                            isCartContainsBeutel = true;
                            isCartContainsOnlyBeutel = false;
                        }

                    }
                    if (c.Sepetim.Count > 1 && item.Name.ToLower() == "beutel")
                    {
                        isCartContainsBeutel = true;
                        isCartContainsOnlyBeutel = false;
                    }

                    totalWeight += item.Amount * item.StkWeight;
                    totalAmount += item.Amount;
                }

                ViewBag.totalAmount = totalAmount;
                ViewBag.beutel = isCartContainsBeutel;
                ViewBag.onlyBeutel = isCartContainsOnlyBeutel;
                ViewBag.totalWeight = totalWeight;
                return View(c);
            }
            else
            {
                ViewBag.nullCart = "Your cart is empty, lets see our products on sale!";
                return View();
            }


        }

        public ActionResult CheckOut()
        {
            Cart c = Session["scart"] as Cart;
            ViewBag.cart = c;
            return View();
        }

        [HttpPost]
        public ActionResult CheckOut(Customer c)
        {
            string orderText = "Order Details \n ";

            try
            {
                _cRep.Add(c);
                int id = c.ID;
                Order o = new Order();
                o.CustomerID = id;
                _oRep.Add(o);
                Cart cart = Session["scart"] as Cart;
                foreach (var item in cart.Sepetim)
                {
                    ProductOrder po = new ProductOrder();
                    po.OrderID = o.ID;
                    po.ProductID = item.ID;
                    po.Quantity = item.Amount;
                    po.Amount = item.SubTotal;
                    po.Status = MODEL.Enums.DataStatus.Inserted;
                    _poRep.Add(po);
                    orderText += $"Product Name:{item.Name} Amount: {item.Amount} Subtotal: {item.SubTotal} \n";
                }
                MailSender.Send(c.Mail, body: $"We received your order successfully! Order ID: {o.ID} \n Customer Name: {c.Name} {c.Surname} \n Company:{c.Company} \n Address: {c.Address} \n {orderText}", subject: "Your order created successfully.");
                MailSender.Send("bestellung@greenstein.eu", body: $" New order arrival! Order ID: {o.ID} \n Customer Name: {c.Name} {c.Surname} \n Company:{c.Company} \n Address: {c.Address} \n {orderText}", subject: "New order arrival!");

                Session.Remove("scart");
                TempData["orderId"] = o.ID;
                return RedirectToAction("CheckOutSuccess");
            }
            catch (Exception)
            {

                ViewBag.error = "We encountered a problem while processing your order. Please try again later.";
                return View();

            }

        }

        public decimal CheckWeightPrice(int weight)
        {
            decimal price = _pcRep.Where(x => x.MinimumWeight <= weight && weight <= x.MaximumWeight).FirstOrDefault().Price;
            return price;
        }

        public ActionResult CheckOutSuccess()
        {
            ViewBag.oId = TempData["orderId"];
            return View();
        }

        public string ChangeAmount(int id, short amount)
        {

            string result = "";
            int totalAmount = 0;
            decimal totalPrice = 0;
            bool isCartContainsBeutel = false;
            bool isCartContainsOnlyBeutel = false;
            Cart c = Session["scart"] as Cart;
            c.ChangeAmount(id, amount);
            int totalWeight = c.TotalWeight;
            totalPrice = Convert.ToDecimal(c.TotalPrice);
            foreach (var item in c.Sepetim)
            {
                if (c.Sepetim.Count == 1 && item.Name.ToLower() == "beutel")
                {
                    if (item.Amount == 1)
                    {
                        isCartContainsBeutel = true;
                        isCartContainsOnlyBeutel = true;
                    }
                    if (item.Amount > 1)
                    {
                        isCartContainsBeutel = true;
                        isCartContainsOnlyBeutel = false;
                    }

                }
                if (c.Sepetim.Count > 1 && item.Name.ToLower() == "beutel")
                {
                    isCartContainsBeutel = true;
                    isCartContainsOnlyBeutel = false;
                }
                totalAmount += item.Amount;
            }
            result = $"{totalPrice}/{totalAmount}/{totalWeight}/{isCartContainsBeutel}/{isCartContainsOnlyBeutel}";
            return result;

        }

        public decimal DeleteCartItem(int id)
        {
            Cart c = Session["scart"] as Cart;
            c.DeleteFromCart(id);
            decimal total = Convert.ToDecimal(c.TotalPrice);
            return total;
        }
    }
}