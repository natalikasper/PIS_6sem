using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace lab05_mvc_task2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("C01_1", "CResearch", new { controller = "CResearch", action = "C01" });
            routes.MapRoute("C01_2", "CResearch/C01", new { controller = "CResearch", action = "C01" });
            routes.MapRoute("C02_1", "CResearch/C02", new { controller = "CResearch", action = "C02" });
        }
    }
}
