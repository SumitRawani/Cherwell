using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Cherwell
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ActionAPI",
                routeTemplate: "actionApi/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Return JSON by default
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //Format JSON
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Send error details to client
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
        }
    }
}
