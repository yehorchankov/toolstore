#region

using System.Web.Mvc;
using System.Web.Routing;

#endregion

namespace ToolStore.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Buy", "Shipment/Buy/{id}",
                new {controller = "Shipment", action = "Buy", id = UrlParameter.Optional});

            routes.MapRoute("Details", "Product/Details/{id}",
                new { controller = "Product", action = "Details", id = UrlParameter.Optional });

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Product", action = "Index", id = UrlParameter.Optional}
                );

        }
    }
}