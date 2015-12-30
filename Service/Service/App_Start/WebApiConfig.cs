using System.Web.Http;

namespace Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{num1}/{num2}/{act}",
                defaults: new { num1 = RouteParameter.Optional, num2 = RouteParameter.Optional, act = RouteParameter.Optional}
            );
        }
    }
}
