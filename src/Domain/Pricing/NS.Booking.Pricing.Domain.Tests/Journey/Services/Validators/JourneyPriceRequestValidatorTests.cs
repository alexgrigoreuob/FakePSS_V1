namespace NS.Booking.Pricing.Domain.Tests.Journey.Services.Validators
{
    using NS.Booking.Pricing.Domain.Journey.Enums;
    using NS.Booking.Pricing.Domain.Journey.Exceptions;
    using NS.Booking.Pricing.Domain.Journey.Models.Requests;
    using NS.Booking.Pricing.Domain.Journey.Services.Validators;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class JourneyPriceRequestValidatorTests
    {
        private JourneyPriceRequestValidator _sut;

        private JourneyPriceRequest _validRequest;

        [SetUp]
        public void SetUp()
        {
            _sut = new JourneyPriceRequestValidator();
            _validRequest = new JourneyPriceRequest
                                {
                                    Origin = "BCN",
                                    Destination = "MAD",
                                    Details = new Dictionary<AvailabilityRequestType, List<DateRange>>
                                                   {
                                                        {
                                                           AvailabilityRequestType.LowestPrice, 
                                                            new List<DateRange>
                                                                {
                                                                    new DateRange
                                                                        {
                                                                            Begin = "2050-10-12",
                                                                            End = "2150-10-12"
                                                                        }
                                                                }
                                                            }
                                                   },
                                    Pax = new Dictionary<string, int>
                                              {
                                                  { "ADT", 1 }
                                              },
                                    Currency = "EUR",
                                    PointOfSale = new PointOfSale
                                                      {
                                                          Country = "ES"
                                                      },
                                    PromoCode = "PromoCode"
            };
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("INVALID")]
        [TestCase("IN")]
        public void ThrowsWhenOriginIsNotAnIataCodeOrStar(string value)
        {
            this._validRequest.Origin = value;

            Assert.Throws<InvalidPricingRequestException>(() => this._sut.Validate(this._validRequest));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("INVALID")]
        [TestCase("IN")]
        public void ThrowsWhenDestinationIsNotAnIataCodeOrStar(string value)
        {
            this._validRequest.Destination = value;

            Assert.Throws<InvalidPricingRequestException>(() => this._sut.Validate(this._validRequest));
        }

        [Test]
        public void ThrowsWhenAvailabilityRequestTypeIsDefault()
        {
            this._validRequest.Details =
                new Dictionary<AvailabilityRequestType, List<DateRange>>
                    {
                        { 
                            AvailabilityRequestType.Default,
                            new List<DateRange>
                                {
                                    new DateRange
                                        {
                                            Begin = "2050-10-12",
                                            End = "2150-10-12"
                                        }
                                }
                        }
                    };

            Assert.Throws<InvalidPricingRequestException>(() => this._sut.Validate(this._validRequest));
        }

        [Test]
        public void ThrowsWhenAvailabilityRequestEndDateIsBeforeBeginDate()
        {
            this._validRequest.Details =
                new Dictionary<AvailabilityRequestType, List<DateRange>>
                    {
                        {
                            AvailabilityRequestType.AllPrice,
                            new List<DateRange>
                                {
                                    new DateRange
                                        {
                                            Begin = "2150-10-12",
                                            End = "2050-10-12"
                                        }
                                }
                        }
                    };

            Assert.Throws<InvalidPricingRequestException>(() => this._sut.Validate(this._validRequest));
        }

        [TestCase(null, "2050-10-12")]
        [TestCase("", "2050-10-12")]
        [TestCase("2050/10/12", "2050-10-12")]
        [TestCase("2050-1-12", "2050-10-12")]
        [TestCase("2050-10-1", "2050-10-12")]
        [TestCase("22-12-2050", "2050-10-12")]
        [TestCase("12-22-2050", "2050-10-12")]
        [TestCase("Invalid", "2050-10-12")]
        [TestCase("2050-10-12", null)]
        [TestCase("2050-10-12", "")]
        [TestCase("2050-10-12", "2050/10/12")]
        [TestCase("2050-10-12", "2050-1-12")]
        [TestCase("2050-10-12", "2050-10-1")]
        [TestCase("2050-10-12", "22-12-2050")]
        [TestCase("2050-10-12", "12-22-2050")]
        [TestCase("2050-10-12", "Invalid")]
        public void ThrowsWhenAvailabilityRequestDatesHaveNotValidFormat(string beginDate, string endDate)
        {
            this._validRequest.Details =
                new Dictionary<AvailabilityRequestType, List<DateRange>>
                    {
                        {
                            AvailabilityRequestType.AllPrice,
                            new List<DateRange>
                                {
                                    new DateRange
                                        {
                                            Begin = beginDate,
                                            End = endDate
                                        }
                                }
                        }
                    };

            Assert.Throws<InvalidPricingRequestException>(() => this._sut.Validate(this._validRequest));
        }

        [TestCase("", 1)]
        [TestCase("INVALID", 1)]
        [TestCase("IN", 1)]
        public void ThrowsWhenPassengersHaveNotValidFormat(string paxCode, int paxNumber)
        {
            this._validRequest.Pax = new Dictionary<string, int>
                                         {
                                             { paxCode, paxNumber }
                                         };

            Assert.Throws<InvalidPricingRequestException>(() => this._sut.Validate(this._validRequest));
        }

        [TestCase("INVALID")]
        [TestCase("IN")]
        public void ThrowsWhenCurrencyHasNotValidFormat(string value)
        {
            this._validRequest.Currency = value;

            Assert.Throws<InvalidPricingRequestException>(() => this._sut.Validate(this._validRequest));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("INVALID")]
        [TestCase("I")]
        public void ThrowsWhenPointOfSaleHasNotValidFormat(string value)
        {
            this._validRequest.PointOfSale = new PointOfSale
                                                 {
                                                    Country = value 
                                                 };

            Assert.Throws<InvalidPricingRequestException>(() => this._sut.Validate(this._validRequest));
        }

        [Test]
        public void DoesNotThrowWhenModelIsValid()
        {
            Assert.DoesNotThrow(() => this._sut.Validate(this._validRequest));
        }

        [TestCase(null)]
        [TestCase("")]
        public void DoesNotThrowWhenCurrencyIsNotSet(string value)
        {
            this._validRequest.Currency = value;
            Assert.DoesNotThrow(() => this._sut.Validate(this._validRequest));
        }

        [Test]
        public void DoesNotThrowWhenPointOfSaleIsNotSet()
        {
            this._validRequest.PointOfSale = null;
            Assert.DoesNotThrow(() => this._sut.Validate(this._validRequest));
        }

        [Test]
        public void DoesNotThrowWhenAvailabilityRequestEndDateIsEqualToBeginDate()
        {
            this._validRequest.Details =
                new Dictionary<AvailabilityRequestType, List<DateRange>>
                    {
                        {
                            AvailabilityRequestType.AllPrice,
                            new List<DateRange>
                                {
                                    new DateRange
                                        {
                                            Begin = "2050-10-12",
                                            End = "2050-10-12"
                                        }
                                }
                        }
                    };

            Assert.DoesNotThrow(() => this._sut.Validate(this._validRequest));
        }
    }
}