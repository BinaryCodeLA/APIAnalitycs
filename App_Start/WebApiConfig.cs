﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestApiWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

           
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            var corsAttr = new EnableCorsAttribute("http://localhost:5500 , https://binarycodela.github.io", "*", "*");
            config.EnableCors(corsAttr);
           
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}