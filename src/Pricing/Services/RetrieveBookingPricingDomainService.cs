using System;
using System.Collections.Generic;
using Newshore.Core.Storage.Interfaces;
using NS.Booking.Pricing.Domain.Journey.Models;
using NS.Booking.Pricing.Domain.Service.Models;
using NS.Booking.Pricing.Domain.Service.Services;

namespace NS.Booking.Infrastructure.Fake.Pricing.Services
{
    public class RetrieveBookingPricingDomainService : IRetrieveBookingPricingDomainService
    {
        private readonly IStoreInSessionStrategy _sessionStorage;

        public RetrieveBookingPricingDomainService(IStoreInSessionStrategy sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public BookingPricing Retrieve()
        {
            var currentBooking = _sessionStorage.Get<BookingPricing>("DomainBooking");

            BookingPricing bookingPricing;

            if (currentBooking != null)
            {
                bookingPricing = currentBooking;
            }
            else
            {
                bookingPricing = new BookingPricing
                {
                    Currency = "EUR",
                    Journeys = new List<Journey>
                    {
                        new Journey
                        {
                            ReferenceId = "AAA000",
                            Segments = new List<Segment>
                            {
                                new Segment
                                {
                                    ReferenceId = "ABC01",
                                    Transport = new Transport { Carrier = new Carrier { Code = "E9"}, Number = "VU101"},
                                    Legs = new List<Leg>
                                    {
                                        new Leg
                                        {
                                            Origin = "MAD",
                                            Destination = "CUN",
                                            STD = DateTime.Today
                                        }
                                    }
                                },
                                new Segment
                                {
                                    ReferenceId = "ABC02",
                                    Transport = new Transport { Carrier = new Carrier { Code = "E9"}, Number = "VU102"},
                                    Legs = new List<Leg>
                                    {
                                        new Leg
                                        {
                                            Origin = "CUN",
                                            Destination = "MAD",
                                            STD = DateTime.Today.AddDays(1)
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
            }

            return bookingPricing;
        }
    }
}
