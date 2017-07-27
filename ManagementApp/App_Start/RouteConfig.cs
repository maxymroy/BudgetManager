using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ManagementApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Clothes",
                url: "clothes",
                defaults: new { controller = "Suits", action = "Clothes" }
            );

            routes.MapRoute(
                name: "Comments",
                url: "comments",
                defaults: new { controller = "Suits", action = "Comments" }
            );

            routes.MapRoute(
                name: "NewClothes",
                url: "clothes/new",
                defaults: new { controller = "Suits", action = "AddClothes" }
            );

            routes.MapRoute(
                name: "Colors",
                url: "colors",
                defaults: new { controller = "Suits", action = "Colors" }
                );

            routes.MapRoute(
                name: "ClothesTypes",
                url: "clothestypes",
                defaults: new { controller = "Suits", action = "ClothesTypes" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
