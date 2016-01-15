﻿#region

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

#endregion

namespace ToolStore.UI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}