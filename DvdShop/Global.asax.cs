using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DvdShop.Mapping;

namespace DvdShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AutoMapperConfiguration.Configure();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            Session["user"] = null;
            Session["fullname"] = null;
        }
    }
}
