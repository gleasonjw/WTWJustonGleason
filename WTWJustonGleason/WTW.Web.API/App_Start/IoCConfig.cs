using System.Web.Http;
using WTW.IoC;

namespace WTW.Web.API.App_Start
{
    public static class IoCConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new WTWContainer();

            // TODO: register types.

            // Set the DependencyResolver to enable dependency injection in WebAPI controllers.
            config.DependencyResolver = new WTWDependencyResolver(container);
        }
    }
}