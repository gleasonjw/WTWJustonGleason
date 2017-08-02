
namespace WTW.IoC.LifeTime
{
    /// <summary>
    /// IoC lifetime manager for transient objects.
    /// </summary>
    public class TransientLifeTimeManager : LifeTimeManager
    {
        internal override object GetObject()
        {
            return null;
        }

        internal override void SetObject(object value)
        {
            // Do nothing.
            // Transient objects should not be stored because they need to be recreated every time they are requested.
        }
    }
}
