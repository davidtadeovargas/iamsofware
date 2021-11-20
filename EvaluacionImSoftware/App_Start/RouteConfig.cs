using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EvaluacionImSoftware
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
                name: "personaCreate",
                url: "{controller}/{action}",
                defaults: new { controller = "Persona", action = "create"}
            );
            routes.MapRoute(
                name: "personaDelete",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Persona", action = "delete" }
            );
            routes.MapRoute(
               name: "personaGet",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Persona", action = "get" }
           );
            routes.MapRoute(
               name: "personaGetAll",
               url: "{controller}/{action}",
               defaults: new { controller = "Persona", action = "getAll" }
           );
        }
    }
}
