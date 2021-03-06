﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace lab05_mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("M01_1", "MResearch/M01/1", new { controller = "MResearch", action = "M01" });
            routes.MapRoute("M01_2", "MResearch/M01", new { controller = "MResearch", action = "M01" });
            routes.MapRoute("M01_3", "MResearch", new { controller = "MResearch", action = "M01" });
            routes.MapRoute("M01_4", "V2/MResearch/M01", new { controller = "MResearch", action = "M01" });
            routes.MapRoute("M01_5", "V3/MResearch/X/M01", new { controller = "MResearch", action = "M01" });

            routes.MapRoute("M02_1", "V2/MResearch/M02", new { controller = "MResearch", action = "M02" });
            routes.MapRoute("M02_2", "V2/MResearch", new { controller = "MResearch", action = "M02" });
            routes.MapRoute("M02_3", "V2", new { controller = "MResearch", action = "M02" });
            routes.MapRoute("M02_4", "V3/MResearch/X/M02", new { controller = "MResearch", action = "M02" });
            routes.MapRoute("M02_5", "MResearch/M02", new { controller = "MResearch", action = "M02" });

            routes.MapRoute("M03_1", "V3/MResearch/X/M03", new { controller = "MResearch", action = "M03" });
            routes.MapRoute("M03_2", "V3/MResearch/X/", new { controller = "MResearch", action = "M03" });
            routes.MapRoute("M03_3", "V3", new { controller = "MResearch", action = "M03" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "MResearch", action = "M01" });
        }
    }
}
