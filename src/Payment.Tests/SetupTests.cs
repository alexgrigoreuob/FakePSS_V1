using Newshore.Core.IoC;
using Newshore.Core.Logger;
using NUnit.Framework;

namespace NS.Booking.Infrastructure.Fake.Payment.Tests
{
    [SetUpFixture]
    public class SetupTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            LoggerBootstrapper.Initialize();
            IoCBootstrapper.Initialize();
        }
    }
}
