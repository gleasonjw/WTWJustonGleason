
namespace WTW.IoC.LifeTime
{
    public class SingletonLifeTimeManager : LifeTimeManager
    {
        private object _storedObject = null;

        internal override object GetObject()
        {
            return _storedObject;
        }

        internal override void SetObject(object value)
        {
            _storedObject = value;
        }
    }
}
