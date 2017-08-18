using System.Web.Routing;

namespace MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "List",
                url: "",
                defaults: new { controller = "List", action = "List", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Search",
                url: "Search/Search",
                defaults: new { controller = "Search", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Add",
               url: "Add/Add",
               defaults: new { controller = "AddUpdate", action = "AddUpdate", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Search", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}