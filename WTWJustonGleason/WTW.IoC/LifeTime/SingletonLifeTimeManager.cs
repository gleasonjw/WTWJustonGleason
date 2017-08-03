
namespace WTW.IoC.LifeTime
{
    /// <summary>
    /// IoC lifetime manager for singleton objects.
    /// </summary>
    public class SingletonLifeTimeManager : LifeTimeManager
    {
        private object _storedObject = null;

        public override object GetObject()
        {
            return _storedObject;
        }

        public override void SetObject(object value)
        {
            _storedObject = value;
        }
    }
}
