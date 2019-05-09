using System.Web.Mvc;
using System.Web.Routing;

namespace LND.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
          name: "Search",
          url: "tim-kiem-html",
          defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
          namespaces: new string[] { "LND.Web.Controllers" }

      );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
          name: "Contact",
          url: "lien-he-html",
          defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
          namespaces: new string[] { "LND.Web.Controllers" }
      );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
          name: "Home",
          url: "trang-chu-html",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
          namespaces: new string[] { "LND.Web.Controllers" }
      );
            routes.MapRoute(
             name: "Product",
             url: "{alias}-p-{id}-html",
             defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                 namespaces: new string[] { "LND.Web.Controllers" }
        );
            routes.MapRoute(
            name: "Product Sale",
            url: "hang-giam-gia-html",
            defaults: new { controller = "Product", action = "Sale", id = UrlParameter.Optional },
                namespaces: new string[] { "LND.Web.Controllers" }
       );

            routes.MapRoute(
           name: "Product Category",
           url: "{alias}-pc-{id}-html",
           defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
             namespaces: new string[] { "LND.Web.Controllers" }
       );
            routes.MapRoute(
           name: "Product By Tag",
           url: "tag-{id}-html",
           defaults: new { controller = "Product", action = "ListByTag", id = UrlParameter.Optional },
               namespaces: new string[] { "LND.Web.Controllers" }
      );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}