using System.Web.Http;
using WTW.IoC;
using WTW.Web.API.Controllers;
using WTW.Web.API.DataAccess;

namespace WTW.Web.API
{
    /// <summary>
    /// Static class to configure the IoC container used for dependency injection.
    /// </summary>
    public static class IoCConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new WTWContainer();

            // Register types.
            container.Register<ResumeController, ResumeController>();
            container.Register<IResumeRepository, ResumeRepositoryXml>();

            // Set the DependencyResolver to enable dependency injection in WebAPI controllers.
            config.DependencyResolver = new WTWDependencyResolver(container);
        }
    }
}