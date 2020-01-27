namespace NS.Booking.Infrastructure.Fake.Pricing.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Newshore.Core.Storage.Interfaces;

    using NS.Booking.Common.Domain.Charge.Enums;
    using NS.Booking.Common.Domain.Charge.Models;
    using NS.Booking.Common.Domain.PricedItem.Enums;
    using NS.Booking.Common.Domain.Service.Enums;
    using NS.Booking.Pricing.Domain.Journey.Models;
    using NS.Booking.Pricing.Domain.Service.Models;
    using NS.Booking.Pricing.Domain.Service.Models.Requests;
    using NS.Booking.Pricing.Domain.Service.Services;

    public class SeatsPricingRetrieverDomainService : IRetrieveServicePricingDomainService
    {
        private readonly Random random;
        private readonly IStoreInSessionStrategy sessionStorage;

        public SeatsPricingRetrieverDomainService(IStoreInSessionStrategy sessionStorage)
        {
            this.sessionStorage = sessionStorage;
            this.random = new Random();
            SupportedTypes = new List<ServiceType>
            {
                ServiceType.Seat
            };
        }

        public List<ServiceType> SupportedTypes { get; }

        public List<Service> Retrieve(ServicePriceRequest request)
        {
            return GenerateServices(request.Booking);
        }

        private List<Service> GenerateServices(BookingPricing booking)
        {
            var services = new List<Service>();
            List<ServiceAvailability> serviceAvailabilities;
            var journeys = booking.Journeys;

            serviceAvailabilities = GenerateServiceAvailabilities(journeys);
            if (serviceAvailabilities.Any())
            {
                services.Add(new Service
                {
                    SellType = ProductScopeType.PerPaxSegment,
                    Availability = serviceAvailabilities,
                    Charges = GenerateServiceCharges(booking.Currency),
                    Info = new ServiceInfo
                    {
                        Code = "SEAT",
                        Name = "Regular seat",
                        Category = "Seat",
                        Type = ServiceType.Seat
                    }
                });
            }

            serviceAvailabilities = GenerateServiceAvailabilities(journeys);
            if (serviceAvailabilities.Any())
            {
                services.Add(new Service
                {
                    SellType = ProductScopeType.PerPaxSegment,
                    Availability = serviceAvailabilities,
                    Charges = GenerateServiceCharges(booking.Currency),
                    Info = new ServiceInfo
                    {
                        Code = "SEATXL",
                        Name = "Extra large seat",
                        Category = "PremiumSeat",
                        Type = ServiceType.Seat
                    }
                });
            }

            serviceAvailabilities = GenerateServiceAvailabilities(journeys);
            if (serviceAvailabilities.Any())
            {
                services.Add(new Service
                {
                    SellType = ProductScopeType.PerPaxSegment,
                    Availability = serviceAvailabilities,
                    Charges = GenerateServiceCharges(booking.Currency),
                    Info = new ServiceInfo
                    {
                        Code = "SEATPLUS",
                        Name = "Premium plus seat",
                        Category = "PremiumSeat",
                        Type = ServiceType.Seat
                    }
                });
            }

            return services;
        }

        private List<ServiceAvailability> GenerateServiceAvailabilities(List<Journey> journeys)
        {
            var serviceAvailabilities = new List<ServiceAvailability>();

            var segmentIds = journeys.SelectMany(j => j.Segments).Select(s => s.Id);

            serviceAvailabilities.AddRange(from segmentId in segmentIds
                                           where GenerateRandom() <= 70
                                           select new ServiceAvailability
                                                      {
                                                          AvailableUnits = GenerateRandom(),
                                                          IsInventoried = GenerateRandom() <= 70,
                                                          LimitPerPax = 1,
                                                          SellKey = segmentId
                                                      });

            return serviceAvailabilities;
        }

        private List<Charge> GenerateServiceCharges(string currency)
        {
            var charges = new List<Charge>
            {
                new Charge
                {
                    Amount = GenerateRandom() * 10,
                    Code = "CH1",
                    Currency = currency,
                    Type = ChargeType.Service
                }
            };

            if (GenerateRandom() > 70)
            {
                charges.Add(new Charge
                {
                    Amount = GenerateRandom() * 10,
                    Code = "SRVTAX",
                    Currency = currency,
                    Type = ChargeType.Tax
                });
            }

            return charges;
        }

        private int GenerateRandom()
        {
            Thread.Sleep(5);
            return this.random.Next(1, 100);
        }
    }
}
