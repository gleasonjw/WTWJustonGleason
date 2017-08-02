using System;

namespace WTW.IoC.Exceptions
{
    public class ResolutionFailedException : Exception
    {
        public ResolutionFailedException(Type serviceType)
            : base($"Resolution of type {serviceType.Name} failed.")
        {

        }
    }
}
