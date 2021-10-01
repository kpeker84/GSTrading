using GSTradingProject.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GSTradingProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "APOCAN";
            return View();
        }

        public ActionResult Uberuns()
        {
            ViewBag.Message = "APOCAN | Uber Uns";
            return View();
        }

        public ActionResult Unternehmen()
        {
            ViewBag.Message = "APOCAN | Unternehmen";
            return View();
        }

        public ActionResult Faq()
        {
            ViewBag.Message = "APOCAN | FAQ";
            return View();
        }

        public ActionResult Karriere()
        {
            ViewBag.Message = "APOCAN | Karriere";
            return View();
        }

        public ActionResult Kontakt()
        {
            ViewBag.Message = "APOCAN | Kontakt";
            return View();
        }

        public ActionResult Professionals()
        {
            ViewBag.Message = "APOCAN | Professionals";
            return View();
        }

        public ActionResult Datenschutz()
        {
            ViewBag.Message = "APOCAN | Datenschutz";
            return View();
        }

        public ActionResult UnsereProdukte()
        {
            ViewBag.Message = "APOCAN | Unsere Produkte";
            return View();
        }

        public ActionResult Service()
        {
            ViewBag.Message = "APOCAN | Service";
            return View();
        }

        public ActionResult Presse()
        {
            ViewBag.Message = "APOCAN | Presse";
            return View();
        }

        public ActionResult Impressum()
        {
            ViewBag.Message = "APOCAN | Impressum";
            return View();
        }

        public ActionResult Login()
        {

            ViewBag.Message = "APOCAN | Login";
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult ProductCheck()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ProductResult(string number)
        {
            if (number == null)
            {
                return RedirectToAction("ProductCheck");
            }
            else
            {
                var client = new RestClient("https://api.businesscentral.dynamics.com/v2.0/d997d32d-0bb9-49fb-8882-dded649bae98/APOCAN_Test/api/v2.0/companies(54a794bd-ddf5-eb11-a1de-0022485b536e)/items");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Basic a3BlY2tlcjpmVWNEeUdGUkl6TFlraTBLUkQyZE10cGZTS0ZzL0krcUcyQjlCSXRoaTA0PQ==");
                IRestResponse response = client.Execute(request);
                var tempResponse = JsonConvert.DeserializeObject<ErpBaseResponse<ErpProductDTO>>(response.Content);
                var choosenProduct = tempResponse.value.FirstOrDefault(x => x.number == number);
                var variants = GetItemVariant(choosenProduct.id);
                ViewBag.variants = variants;
                return View(choosenProduct);
            }

        }

        public List<ItemVariant> GetItemVariant(string id)
        {
            var client = new RestClient($"https://api.businesscentral.dynamics.com/v2.0/d997d32d-0bb9-49fb-8882-dded649bae98/APOCAN_Test/api/v2.0/companies(54a794bd-ddf5-eb11-a1de-0022485b536e)/items({id})/itemVariants");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic a3BlY2tlcjpmVWNEeUdGUkl6TFlraTBLUkQyZE10cGZTS0ZzL0krcUcyQjlCSXRoaTA0PQ==");
            IRestResponse response = client.Execute(request);
            var tempResponse = JsonConvert.DeserializeObject<ErpBaseResponse<ItemVariant>>(response.Content);
            var variants = tempResponse.value;


            var imageLink = GetItemPicture(id);
            ViewBag.imageLink = imageLink;
            return variants;
        }

        public string GetItemPicture(string id)
        {
            var client = new RestClient($"https://api.businesscentral.dynamics.com/v2.0/d997d32d-0bb9-49fb-8882-dded649bae98/APOCAN_Test/api/v2.0/companies(54a794bd-ddf5-eb11-a1de-0022485b536e)/items({id})/picture");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic a3BlY2tlcjpmVWNEeUdGUkl6TFlraTBLUkQyZE10cGZTS0ZzL0krcUcyQjlCSXRoaTA0PQ==");
            IRestResponse response = client.Execute(request);
            var tempResponse = JsonConvert.DeserializeObject<ErpProductImageModel>(response.Content);
            return tempResponse.mediaReadLink;
        }

    }
}