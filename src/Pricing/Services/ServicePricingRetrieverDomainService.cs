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

    public class ServicePricingRetrieverDomainService : IRetrieveServicePricingDomainService
    {
        private readonly Random random;

        private readonly IStoreInSessionStrategy sessionStorage;

        public ServicePricingRetrieverDomainService(IStoreInSessionStrategy sessionStorage)
        {
            this.sessionStorage = sessionStorage;
            this.random = new Random();
            SupportedTypes = new List<ServiceType>
            {
                ServiceType.Baggage, ServiceType.Meal, ServiceType.Insurance, ServiceType.DutyFree,
                ServiceType.SpecialAssistance, ServiceType.Priority, ServiceType.Bundle
            };
        }

        public List<ServiceType> SupportedTypes { get; }

        public List<Service> Retrieve(ServicePriceRequest request)
        {
            var result = new List<Service>();

            foreach (var serviceType in request.ServiceTypes)
            {
                result.AddRange(GenerateServices(serviceType, request.Booking));
            }

            return result;
        }

        /// <summary>
        /// Generate random services for the type and segments indicated.
        /// </summary>
        /// <param name="type">Service type of services to be created.</param>
        /// <param name="journeys">Journey info with segments for service creation.</param>
        /// <returns></returns>
        private List<Service> GenerateServices(ServiceType type, BookingPricing booking)
        {
            var services = new List<Service>();
            List<ServiceAvailability> serviceAvailabilities;
            var journeys = booking.Journeys;

            switch (type)
            {
                case ServiceType.Baggage:
                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "BAG1",
                                Name = "Extra luggage 25kg",
                                Category = "ExtraBag",
                                Type = ServiceType.Baggage
                            }
                        });
                    }

                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "BAG2",
                                Name = "Extra luggage 32kg",
                                Category = "ExtraBag",
                                Type = ServiceType.Baggage
                            }
                        });
                    }

                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "BAG3",
                                Name = "Extra luggage 38kg",
                                Category = "ExtraBag",
                                Type = ServiceType.Baggage
                            }
                        });
                    }

                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "SPEQ",
                                Name = "Special equipment",
                                Category = "SpecialEquipment",
                                Type = ServiceType.Baggage
                            }
                        });
                    }
                    break;
                case ServiceType.Meal:
                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "VEGMEAL",
                                Name = "Vegetarian meal",
                                Category = "Meal",
                                Type = ServiceType.Meal
                            }
                        });
                    }

                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "MEUM",
                                Name = "Meat meal",
                                Category = "Meal",
                                Type = ServiceType.Meal
                            }
                        });
                    }

                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "LIUM",
                                Name = "Gluten free meal",
                                Category = "Meal",
                                Type = ServiceType.Meal
                            }
                        });
                    }

                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "FIUM",
                                Name = "Meat gourmet meal",
                                Category = "PremiumMeal",
                                Type = ServiceType.Meal
                            }
                        });
                    }

                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "PAUM",
                                Name = "Vegetarian gourmet meal",
                                Category = "PremiumMeal",
                                Type = ServiceType.Meal
                            }
                        });
                    }
                    break;
                case ServiceType.Seat:
                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "SWA1",
                                Name = "Regular seat",
                                Category = "Seat",
                                Type = ServiceType.Seat
                            }
                        });
                    }

                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "SXL",
                                Name = "Extra large seat",
                                Category = "PremiumSeat",
                                Type = ServiceType.Seat
                            }
                        });
                    }

                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "ST+",
                                Name = "Premium plus seat",
                                Category = "Seat",
                                Type = ServiceType.Seat
                            }
                        });
                    }
                    break;
                case ServiceType.Insurance:
                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerBooking);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerBooking,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "INS",
                                Name = "Flight Insurance",
                                Category = "Insurance",
                                Type = ServiceType.Insurance
                            }
                        });
                    }
                    break;
                case ServiceType.Priority:
                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "XCKI",
                                Name = "Express check-in",
                                Category = "Check-in",
                                Type = ServiceType.Priority
                            }
                        });
                    }
                    break;
                case ServiceType.SpecialAssistance:
                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "WCHC",
                                Name = "Wheel chair",
                                Category = "Meet and assist",
                                Type = ServiceType.SpecialAssistance
                            }
                        });
                    }
                    break;
                case ServiceType.DutyFree:
                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "DE01",
                                Name = "Perfume",
                                Category = "DutyFree",
                                Type = ServiceType.DutyFree
                            }
                        });
                    }

                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "DE02",
                                Name = "Chocolate",
                                Category = "DutyFree",
                                Type = ServiceType.DutyFree
                            }
                        });
                    }
                    break;
                case ServiceType.Bundle:
                    serviceAvailabilities = GenerateServiceAvailabilities(journeys, ProductScopeType.PerPaxSegment);
                    if (serviceAvailabilities.Any())
                    {
                        services.Add(new Service
                        {
                            SellType = ProductScopeType.PerPaxSegment,
                            Availability = serviceAvailabilities,
                            Charges = GenerateServiceCharges(booking.Currency),
                            Info = new ServiceInfo
                            {
                                Code = "SUT+",
                                Name = "Turista Plus",
                                Category = "Bundle",
                                Type = ServiceType.Bundle
                            }
                        });
                    }
                    break;
                default:
                    break;
            }

            return services;
        }

        /// <summary>
        /// Generate service availabilities for the segment ids present.
        /// </summary>
        /// <param name="journeys">Journeys containing segments available for service creation.</param>
        /// <param name="scopeType">Defines scope type, depending on its value segment o journey availability will be created.</param>
        /// <returns></returns>
        private List<ServiceAvailability> GenerateServiceAvailabilities(List<Journey> journeys, ProductScopeType scopeType)
        {
            var serviceAvailabilities = new List<ServiceAvailability>();

            switch (scopeType)
            {
                case ProductScopeType.PerPaxSegment:
                    var segmentIds = journeys.SelectMany(j => j.Segments).Select(s => s.Id);

                    serviceAvailabilities.AddRange(from segmentId in segmentIds
                        where GenerateRandom() <= 70
                        select new ServiceAvailability
                        {
                            AvailableUnits = GenerateRandom(), IsInventoried = GenerateRandom() <= 70, LimitPerPax = 1,
                            SellKey = segmentId
                        });
                    break;

                case ProductScopeType.PerBooking:
                    var journeyIds = journeys.Select(j => j.Id);

                    if (GenerateRandom() <= 70)
                    {
                        serviceAvailabilities.AddRange(from journeyId in journeyIds
                        select new ServiceAvailability
                        {
                            AvailableUnits = GenerateRandom(),
                            IsInventoried = GenerateRandom() <= 70,
                            LimitPerPax = 1,
                            SellKey = journeyId
                        });
                    }
                    break;
            }

            return serviceAvailabilities;
        }

        /// <summary>
        /// Generate random charges.
        /// </summary>
        /// <returns></returns>
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
                    Type =  ChargeType.Tax
                });
            }

            return charges;
        }

        /// <summary>
        /// Generates random number between 1 and 100.
        /// </summary>
        /// <returns></returns>
        private int GenerateRandom()
        {
            Thread.Sleep(5);
            return this.random.Next(1, 100);
        }
    }
}
