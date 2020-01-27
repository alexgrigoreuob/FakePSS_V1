namespace NS.Booking.Pricing.Domain.Tests
{
    using Newshore.Core.IoC;
    using Newshore.Core.Logger;

    using NS.Booking.Pricing.Domain._IoCInstaller;

    using NUnit.Framework;

    [SetUpFixture]
    public class SetupTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            LoggerBootstrapper.Initialize();
            IoCBootstrapper.Initialize();
            new Installer().Install(LifeStyleType.Thread);
        }
    }
}