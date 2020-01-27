namespace NS.Booking.Pricing.Domain.Tests.Service.Services.Validators
{
    using NS.Booking.Pricing.Domain.Service.Exceptions;
    using NS.Booking.Pricing.Domain.Service.Models;
    using NS.Booking.Pricing.Domain.Service.Models.Requests;
    using NS.Booking.Pricing.Domain.Service.Services.Validators;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ServicePriceRequestValidatorTests
    {
        private ServicePriceRequestValidator _sut;
        private ServicePriceRequest _validRequest;
        private ServicePriceRequest _emptyRequest;

        [SetUp]
        public void SetUp()
        {
            this._sut = new ServicePriceRequestValidator();
            _validRequest = new ServicePriceRequest {
                Booking = new BookingPricing
                {
                    Journeys = new List<Domain.Journey.Models.Journey> { new Domain.Journey.Models.Journey()},
                    Currency = "EUR"
                }
            };

            this._emptyRequest = new ServicePriceRequest
            {
                Booking = new BookingPricing()
            };
        }
        
        [Test]
        public void ThrowsWhenServiceTypesEmpty()
        {
            Assert.Throws<InvalidServicePricingRequestException>(() => this._sut.Validate(this._emptyRequest));
        }

        [Test]
        public void ThrowsWhenServiceTypesNull()
        {
            var nullRequest = new ServicePriceRequest();
            Assert.Throws<InvalidServicePricingRequestException>(() => this._sut.Validate(nullRequest));
        }

        [Test]
        public void DoesNotThrowWhenModelIsValid()
        {
            Assert.DoesNotThrow(() => this._sut.Validate(this._validRequest));
        }
    }
}
