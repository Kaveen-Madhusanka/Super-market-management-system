using SMMS.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SMMS_WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConnectionDetails.ConnetionString = @"Data Source=DESKTOP-7NPAUSD\SQLEXPRESS;Initial Catalog=SMMS;User ID=sa;Password=compaq123";
            ConnectionDetails.Conn = new SqlConnection(ConnectionDetails.ConnetionString);
        }
    }
}
