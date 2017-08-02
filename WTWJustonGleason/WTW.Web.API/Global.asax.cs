using System.Web.Http;

namespace WTW.Web.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Wire up the dependency resolver for dependency injection.
            GlobalConfiguration.Configure(IoCConfig.Register);
        }
    }
}
