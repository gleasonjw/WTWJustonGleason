using System;

namespace WTW.IoC.LifeTime
{
    /// <summary>
    /// Base class for IoC lifetime manager implementations.
    /// </summary>
    public abstract class LifeTimeManager
    {
        public Type DataType { get; set; }

        public abstract void SetObject(object value);
        public abstract object GetObject();
    }
}
