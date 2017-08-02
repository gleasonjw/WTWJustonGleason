using NUnit.Framework;
using WTW.Ioc.Test.TestHelpers;
using WTW.IoC;
using WTW.IoC.LifeTime;

namespace WTW.Ioc.Test
{
    [TestFixture]
    public class WTWContainerTest
    {
        [Test]
        public void TestSimpleTypeRegistration()
        {
            IWTWContainer container = new WTWContainer();
            container.Register<ICalculator, Calculator>();
        }

        [Test]
        public void TestSimpleTypeResolution()
        {
            IWTWContainer container = new WTWContainer();
            container.Register<ICalculator, Calculator>();

            var calc = container.Resolve<ICalculator>();
            Assert.IsNotNull(calc);
        }

        [Test]
        public void TestSimpleTypeResolutionWithParameter()
        {
            IWTWContainer container = new WTWContainer();
            container.Register<ICalculator, Calculator>();

            var calc = container.Resolve(typeof(ICalculator));
            Assert.IsNotNull(calc);
        }

        [Test]
        public void TestResolveUnregisteredType()
        {
            IWTWContainer container = new WTWContainer();
            TestDelegate testFunction = delegate() { container.Resolve<ICalculator>(); };

            Assert.Catch(testFunction);
        }

        [Test]
        public void TestParameterizedConstructorResolution()
        {
            IWTWContainer container = new WTWContainer();
            container.Register<ICalculator, Calculator>();
            container.Register<IEmailService, EmailService>();
            container.Register<IUsersController, UsersController>();

            var ctrl = container.Resolve<IUsersController>();
            Assert.IsNotNull(ctrl);
        }

        [Test]
        public void TestPartiallyRegisteredParameterizedConstructorResolution()
        {
            IWTWContainer container = new WTWContainer();
            container.Register<ICalculator, Calculator>();
            // Missing registration of email service.
            container.Register<IUsersController, UsersController>();

            TestDelegate testFunction = delegate () { container.Resolve<IUsersController>(); };

            Assert.Catch(testFunction);
        }

        [Test]
        public void TestTransientLifecycle()
        {
            IWTWContainer container = new WTWContainer();
            container.Register<ICalculator, Calculator>(new TransientLifeTimeManager());

            var calc1 = container.Resolve<ICalculator>();
            var calc2 = container.Resolve<ICalculator>();

            Assert.AreNotSame(calc1, calc2);
        }

        [Test]
        public void TestTransientLifecycleIsDefault()
        {
            IWTWContainer container = new WTWContainer();
            container.Register<ICalculator, Calculator>();

            var calc1 = container.Resolve<ICalculator>();
            var calc2 = container.Resolve<ICalculator>();

            Assert.AreNotSame(calc1, calc2);
        }

        [Test]
        public void TestSingletonLifecycle()
        {
            IWTWContainer container = new WTWContainer();
            container.Register<ICalculator, Calculator>(new SingletonLifeTimeManager());

            var calc1 = container.Resolve<ICalculator>();
            var calc2 = container.Resolve<ICalculator>();

            Assert.AreSame(calc1, calc2);
        }
    }
}
