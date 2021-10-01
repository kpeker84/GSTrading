using GSTradingProject.BLL.Patterns.Repository.ConcRep;
using GSTradingProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GSTradingProject.Controllers
{
    public class ProfessionalController : Controller
    {
        private ProductRepository _pRep;
        public ProfessionalController()
        {
            _pRep = new ProductRepository();
        }
        // GET: Professional
        public ActionResult Professionals()
        {
            List<Product> products = _pRep.GetAll();
            string a = Request.Url.AbsoluteUri.ToString();
            if (a.Contains("timestamp") || Session["logged"] != null)
            {
                Session["logged"] = "logged";
                return View(products);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            //return View(products);

        }

        public PartialViewResult GetProduct(int id)
        {
            Product pro = _pRep.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.choosenProduct = pro;
            return PartialView("_productView");
        }

        public ActionResult ProductDetail(int id)
        {
            Product p = _pRep.Find(id);
            return View(p);

        }

        public ActionResult ProfessionalMain()
        {
            string a = Request.Url.AbsoluteUri;
            if (a.Contains("timestamp") || Session["logged"] != null)
            {
                Session["logged"] = "logged";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public ActionResult ProfessionalInfo()
        {
            string a = Request.Url.AbsoluteUri;
            if (a.Contains("timestamp") || Session["logged"] != null)
            {
                Session["logged"] = "logged";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }


        public ActionResult NeukundenInfo()
        {
            string a = Request.Url.AbsoluteUri;
            if (a.Contains("timestamp") || Session["logged"] != null)
            {
                Session["logged"] = "logged";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public ActionResult Download()
        {
            string a = Request.Url.AbsoluteUri;
            if (a.Contains("timestamp") || Session["logged"] != null)
            {
                Session["logged"] = "logged";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }


        public ActionResult ProducktrelevanteInformation()
        {
            string a = Request.Url.AbsoluteUri;
            if (a.Contains("timestamp") || Session["logged"] != null)
            {
                Session["logged"] = "logged";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public ActionResult Dronabinol()
        {
            string a = Request.Url.AbsoluteUri;
            if (a.Contains("timestamp") || Session["logged"] != null)
            {
                Session["logged"] = "logged";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public ActionResult Cannabidiol()
        {
            string a = Request.Url.AbsoluteUri;
            if (a.Contains("timestamp") || Session["logged"] != null)
            {
                Session["logged"] = "logged";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public ActionResult Extrakte()
        {
            string a = Request.Url.AbsoluteUri;
            if (a.Contains("timestamp") || Session["logged"] != null)
            {
                Session["logged"] = "logged";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public ActionResult Bluten()
        {
            string a = Request.Url.AbsoluteUri;
            if (a.Contains("timestamp") || Session["logged"] != null)
            {
                Session["logged"] = "logged";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }


    }
}