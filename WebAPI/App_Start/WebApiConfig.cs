using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();

            //To Enable CORS in WebAPI 2 -> Package Manager Console -> Run this command "Install-Package Microsoft.AspNet.WebApi.Cors" and uncomment the following lines
            //config.EnableCors();
            var corsAttr = new EnableCorsAttribute("http://localhost:58901", "*", "*");
            config.EnableCors(corsAttr);

            //config.Routes.MapHttpRoute(
            //    name: "WithoutAction",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { controller = "Customer", id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "WithAction",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Custome ID Name",
                routeTemplate: "api/{controller}/{action}/{customersID}",
                defaults: new { customersID = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //  For removing default XML formater from response
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
