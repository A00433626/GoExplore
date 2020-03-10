using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EventPlanner
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Event List",
                url: "Event/EventList",
                defaults: new { Controller = "Event", action= "EventList", id=UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "Event Data",
                url: "Admin/Dashboad/PagingnationEvent",
                defaults: new { Controller = "Dashboard", action = "PagingnationEvent", pageNo = UrlParameter.Optional }
            );
        }
    }
}
