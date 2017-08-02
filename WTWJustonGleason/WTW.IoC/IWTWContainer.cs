using System;
using System.Collections.Generic;

namespace WTW.IoC
{
    public interface IWTWContainer : IDisposable
    {
        void Register<TFrom, TTo>(LifecycleType lifecycle = LifecycleType.Transient);
        object Resolve<TFrom>();

        #region Required for the WebAPI dependency resolver.
        object Resolve(Type fromType);
        IEnumerable<object> ResolveAll(Type fromType);
        IWTWContainer CreateChildContainer();
        #endregion
    }
}