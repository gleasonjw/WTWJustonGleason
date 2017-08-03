
namespace WTW.IoC.LifeTime
{
    /// <summary>
    /// IoC lifetime manager for transient objects.
    /// </summary>
    public class TransientLifeTimeManager : LifeTimeManager
    {
        public override object GetObject()
        {
            return null;
        }

        public override void SetObject(object value)
        {
            // Do nothing.
            // Transient objects should not be stored because they need to be recreated every time they are requested.
        }
    }
}
