using System;
using System.Collections.Generic;
using WTW.IoC.LifeTime;

namespace WTW.IoC
{
    /// <summary>
    /// Simple IoC container built for WTW code challenge.
    /// </summary>
    public interface IWTWContainer : IDisposable
    {
        void Register<TFrom, TTo>();
        void Register<TFrom, TTo>(LifeTimeManager lifeTimeMgr);
        object Resolve<TFrom>();

        #region Required for the WebAPI dependency resolver.
        object Resolve(Type fromType);
        IEnumerable<object> ResolveAll(Type fromType);
        IWTWContainer CreateChildContainer();
        #endregion
    }
}