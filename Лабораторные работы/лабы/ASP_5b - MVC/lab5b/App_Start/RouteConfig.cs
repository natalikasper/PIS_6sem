using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace lab5b
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute("M02_1", "chresearch/ad", new { controller = "CHResearch", action = "AD" });
            routes.MapRoute("M02_2", "chresearch/ap", new { controller = "CHResearch", action = "AP" });

            routes.MapRoute("M03_1", "aresearch/aa", new { controller = "AResearch", action = "AA" });
            routes.MapRoute("M03_2", "aresearch/ar", new { controller = "AResearch", action = "AR" });
            routes.MapRoute("M03_3", "aresearch/ae", new { controller = "AResearch", action = "AE" });

            routes.MapRoute(
                           name: "Default",
                           url: "{controller}/{action}/{id}",
                           defaults: new { controller = "MResearch", action = "M01B", id = UrlParameter.Optional });
           
           }
    }
}
//new { httpMethod = new HttpMethodConstraint("POST")