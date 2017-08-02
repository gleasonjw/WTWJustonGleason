using System;
using System.Collections.Generic;

namespace WTW.IoC
{
    public interface IWTWContainer : IDisposable
    {
        void Register<TFrom, TTo>(LifeCycleType lifecycle = LifeCycleType.Transient);
        object Resolve<TFrom>();

        #region Required for the WebAPI dependency resolver.
        object Resolve<TFrom>(TFrom serviceType);
        IEnumerable<object> ResolveAll(Type serviceType);
        IWTWContainer CreateChildContainer();
        #endregion
    }
}