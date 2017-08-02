using NUnit.Framework;
using WTW.Ioc.Test.TestHelpers;
using WTW.IoC;

namespace WTW.Ioc.Test
{
    [TestFixture]
    public class WTWContainerTest
    {
        [Test]
        public void SimpleTypeRegistration()
        {
            IWTWContainer container = new WTWContainer();
            container.Register<ICalculator, Calculator>();
        }

        [Test]
        public void SimpleTypeResolution()
        {
            IWTWContainer container = new WTWContainer();
            container.Register<ICalculator, Calculator>();

            var calc = container.Resolve<ICalculator>();
            Assert.IsNotNull(calc);
        }

        [Test]
        public void SimpleTypeResolutionWithParameter()
        {
            IWTWContainer container = new WTWContainer();
            container.Register<ICalculator, Calculator>();

            var calc = container.Resolve(typeof(ICalculator));
            Assert.IsNotNull(calc);
        }
    }
}
