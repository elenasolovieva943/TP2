using System.Web.Mvc;
using System.Web.Routing;

namespace FitnessAppMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Custom",
                url: "Custom/start/{id}",
                defaults: new { controller = "Custom", action = "start", id = "0" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Fitness", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}