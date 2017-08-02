using System;
using System.Collections.Generic;

namespace WTW.IoC
{
    public class WTWContainer : IWTWContainer
    {
        public IWTWContainer CreateChildContainer()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Register<TFrom, TTo>(LifeCycleType lifecycle = LifeCycleType.Transient)
        {
            throw new NotImplementedException();
        }

        public object Resolve<TFrom>()
        {
            throw new NotImplementedException();
        }

        public object Resolve<TFrom>(TFrom serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> ResolveAll(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
