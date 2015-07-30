using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ContactManagerWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ApiById",
                routeTemplate: "api/{controller}/{id}"
                , defaults: new { id = RouteParameter.Optional }
                //,constraints: new { id = @"^[0-9]+$" }
                );

            config.Routes.MapHttpRoute(
                name: "ApiBySearchString"
                , routeTemplate: "api/{controller}/{action}/{searchString}"
                , defaults: null
                );

            config.Routes.MapHttpRoute(
                name: "ApiByAction",
                routeTemplate: "api/{controller}/{action}"
                //defaults: new { action = "Get" }
                );

            config.EnableSystemDiagnosticsTracing();
        }
    }
}
