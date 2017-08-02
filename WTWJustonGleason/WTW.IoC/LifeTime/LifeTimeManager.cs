using System;

namespace WTW.IoC.LifeTime
{
    public abstract class LifeTimeManager
    {
        internal Type DataType { get; set; }

        internal abstract void SetObject(object value);
        internal abstract object GetObject();
    }
}
