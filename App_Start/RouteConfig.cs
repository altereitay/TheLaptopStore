﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TheLaptopStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "Register",
                url: "Register",
                defaults: new { controller = "Register", action = "Index", id = UrlParameter.Optional }
            );
            */
            routes.MapRoute(
            name: "Login",
            url: "",
            defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
        );
            routes.MapRoute(
          name: "Default2",
          url: "Submit",
          defaults: new { controller = "LogIn", action = "Submit", id = UrlParameter.Optional }
          );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
