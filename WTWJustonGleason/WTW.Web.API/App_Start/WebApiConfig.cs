using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WTW.Web.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors(new EnableCorsAttribute("*", "*", "GET"));
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
