using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace bachhoaxanhdemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Product",
               url: "title-{id}/product-{idProd}",
                new { controller = "DetailProduct", action = "indexDetail", id = UrlParameter.Optional, idProd = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "ProductTitles",
               url: "title-{id}",
                new { controller = "ProductTitles", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "AddToCart",
               url: "add-to-cart",
                new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Cart",
               url: "cart",
                new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
