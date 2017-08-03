using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using WTW.IoC;
using WTW.IoC.Exceptions;

namespace WTW.Web.API
{
    /// <summary>
    /// The WTWDependencyResolver class is a wrapper around WTWContainer as required for dependency injection in WebAPI controllers.
    /// <see cref="https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/dependency-injection"/>
    /// </summary>
    public class WTWDependencyResolver : IDependencyResolver
    {
        private IWTWContainer _container;

        public WTWDependencyResolver(IWTWContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            // Note: For this simple implementation, I didn't add support for nested containers.
            return new WTWDependencyResolver(_container);
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                // Note: For this simple implementation, the container just resolves the first matching object.
                List<object> returnValue = new List<object>();
                returnValue.Add(_container.Resolve(serviceType));

                return returnValue;
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _container.Dispose();
        }
    }
}