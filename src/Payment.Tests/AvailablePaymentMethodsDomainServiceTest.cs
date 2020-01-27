using NS.Booking.Domain.Payment.Services;
using NS.Booking.Infrastructure.Fake.Payment.Services;
using NUnit.Framework;

namespace NS.Booking.Infrastructure.Fake.Payment.Tests
{
    [TestFixture]
    public class AvailablePaymentMethodsDomainServiceTest
    {
        private IAvailablePaymentMethodsDomainService _domainService;

        [SetUp]
        public void SetUp()
        {
            _domainService = new AvailablePaymentMethodsDomainService();
        }

        [Test]
        public void ShouldReturnValidPaymentMethodList()
        {
            var paymentMethods = _domainService.GetAvailablePaymentMethods();

            Assert.IsNotNull(paymentMethods);
            Assert.Greater(paymentMethods.Count, 0);
        }
    }
}
