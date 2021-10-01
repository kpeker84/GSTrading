using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GSTradingProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Home/Index");
            routes.MapRoute("Index", "", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute("Faq", "Faq", new { controller = "Home", action = "Faq", id = UrlParameter.Optional });
            routes.MapRoute("Karriere", "Karriere", new { controller = "Home", action = "Karriere", id = UrlParameter.Optional });
            routes.MapRoute("Kontakt", "Kontakt", new { controller = "Home", action = "Kontakt", id = UrlParameter.Optional });
            routes.MapRoute("Uberuns", "Uberuns", new { controller = "Home", action = "Uberuns", id = UrlParameter.Optional });
            routes.MapRoute("Unsereprodukte", "Unsereprodukte", new { controller = "Home", action = "Unsereprodukte", id = UrlParameter.Optional });
            routes.MapRoute("Datenschutz", "Datenschutz", new { controller = "Home", action = "Datenschutz", id = UrlParameter.Optional });
            routes.MapRoute("Impressum", "Impressum", new { controller = "Home", action = "Impressum", id = UrlParameter.Optional });
            routes.MapRoute("Login", "Login", new { controller = "Home", action = "Login", id = UrlParameter.Optional });
            routes.MapRoute("Professionals", "Professionals", new { controller = "Professional", action = "Professionals", id = UrlParameter.Optional });
            routes.MapRoute("ProfessionalMain", "ProfessionalMain", new { controller = "Professional", action = "ProfessionalMain", id = UrlParameter.Optional });
            routes.MapRoute("Dronabinol", "Dronabinol", new { controller = "Professional", action = "Dronabinol", id = UrlParameter.Optional });
            routes.MapRoute("Cannabidiol", "Cannabidiol", new { controller = "Professional", action = "Cannabidiol", id = UrlParameter.Optional });
            routes.MapRoute("Extrakte", "Extrakte", new { controller = "Professional", action = "Extrakte", id = UrlParameter.Optional });
            routes.MapRoute("Bluten", "Bluten", new { controller = "Professional", action = "Bluten", id = UrlParameter.Optional });
            routes.MapRoute("Download", "Download", new { controller = "Professional", action = "Download", id = UrlParameter.Optional });
            routes.MapRoute("Unternehmen", "Unternehmen", new { controller = "Home", action = "Unternehmen", id = UrlParameter.Optional });
            routes.MapRoute("Service", "Service", new { controller = "Home", action = "Service", id = UrlParameter.Optional });
            routes.MapRoute("Presse", "Presse", new { controller = "Home", action = "Presse", id = UrlParameter.Optional });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
