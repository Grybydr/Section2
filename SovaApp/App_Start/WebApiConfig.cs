﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SovaApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "HistoryApi",
                routeTemplate: "api/History/{id}",
                defaults: new { controller = "History",id = RouteParameter.Optional }
            );
        }
    }
}
