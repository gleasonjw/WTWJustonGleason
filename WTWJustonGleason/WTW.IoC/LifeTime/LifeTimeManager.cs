using System;

namespace WTW.IoC.LifeTime
{
    /// <summary>
    /// Base class for IoC lifetime manager implementations.
    /// </summary>
    public abstract class LifeTimeManager
    {
        internal Type DataType { get; set; }

        internal abstract void SetObject(object value);
        internal abstract object GetObject();
    }
}
