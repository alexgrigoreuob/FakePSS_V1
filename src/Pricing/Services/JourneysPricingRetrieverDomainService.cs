namespace NS.Booking.Infrastructure.Fake.Pricing.Services
{
    using Newshore.Core.Storage.Interfaces;
    using NS.Booking.Common.Domain.Charge.Enums;
    using NS.Booking.Common.Domain.Charge.Models;
    using NS.Booking.Pricing.Domain.Journey.Enums;
    using NS.Booking.Pricing.Domain.Journey.Models;
    using NS.Booking.Pricing.Domain.Journey.Models.Requests;
    using NS.Booking.Pricing.Domain.Journey.Models.Responses;
    using NS.Booking.Pricing.Domain.Journey.Services;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class JourneysPricingRetrieverDomainService : IRetrieveJourneysPricingDomainService
    {
        private readonly IStoreInSessionStrategy sessionStorage;

        private readonly Random random;

        public JourneysPricingRetrieverDomainService(IStoreInSessionStrategy sessionStorage)
        {
            this.sessionStorage = sessionStorage;
            this.random = new Random();
        }

        public List<AvailabilityRequestType> AllowedRequestTypes
        {
            get => 
                new List<AvailabilityRequestType>
                   {
                        AvailabilityRequestType.AllPrice,
                        AvailabilityRequestType.LowestPrice
                   };
        }

        public AvailabilityRequestMethod AllowedRequestMethod
        {
            get => AvailabilityRequestMethod.RealTime;
        }

        public List<JourneyPriceResponse> Retrieve(List<JourneyPriceRequest> requests)
        {
            var response = new List<JourneyPriceResponse>();

            requests.ForEach(request => { response.Add(this.GenerateValidResponse(request)); });

            var journeys = response.SelectMany(
                x => x.Schedules.SelectMany(
                    y => y.Journeys.Where(z => z.ScheduleType == AvailabilityRequestType.AllPrice)));

            var savedJourneys = this.sessionStorage.Get<List<Journey>>("Availabilities") ?? new List<Journey>();

            savedJourneys.AddRange(journeys);

            this.sessionStorage.Add("Availabilities", savedJourneys);

            return response;
        }

        private JourneyPriceResponse GenerateValidResponse(JourneyPriceRequest request)
        {
            return new JourneyPriceResponse
                       {
                           Currency = request.Currency,
                           Id = request.Id,
                           Schedules = this.GenerateSchedules(request)
                       };
        }

        private List<Schedule> GenerateSchedules(JourneyPriceRequest request)
        {
            var response = new List<Schedule>();

            request.Details.Keys.ToList().ForEach(key =>
                {
                    var dateRanges = request.Details[key];
                    dateRanges.ForEach(
                        dateRange =>
                            {
                                response.AddRange(this.GenerateDetailedSchedule(request, key, dateRange, response));
                            });
                });

            return response;
        }

        private List<Schedule> GenerateDetailedSchedule(
            JourneyPriceRequest request,
            AvailabilityRequestType requestType,
            DateRange dateRange,
            List<Schedule> currentSchedules)
        {
            var schedules = new List<Schedule>();
            var beginDate = DateTime.ParseExact(dateRange.Begin, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(dateRange.End, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            while (endDate >= beginDate)
            {
                bool scheduleIsAvailable = true;
                var currentSchedule = currentSchedules.FirstOrDefault(schedule => schedule.Date.ToString("yyyy-MM-dd") == beginDate.ToString("yyyy-MM-dd"));
                if (currentSchedule == null)
                {
                    currentSchedule = new Schedule { Date = beginDate, Journeys = new List<Journey>() };
                    schedules.Add(currentSchedule);
                }
                else
                {
                    scheduleIsAvailable = currentSchedule.Availability == ScheduleAvailabilityType.Available;
                }

                if (scheduleIsAvailable)
                {
                    var randomAvailability = this.GenerateRandom();
                    if (randomAvailability > 10)
                    {
                        currentSchedule.Availability = ScheduleAvailabilityType.Available;
                        currentSchedule.Journeys.AddRange(
                            this.GenerateJourneys(request, beginDate, requestType, ScheduleAvailabilityType.Available));
                    }
                    else if (randomAvailability > 5)
                    {
                        currentSchedule.Availability = ScheduleAvailabilityType.SoldOut;
                        currentSchedule.Journeys.AddRange(
                            this.GenerateJourneys(request, beginDate, requestType, ScheduleAvailabilityType.SoldOut));
                    }
                    else
                    {
                        currentSchedule.Availability = ScheduleAvailabilityType.NotAvailable;
                    }
                }

                beginDate = beginDate.AddDays(1);
            }

            return schedules;
        }

        private List<Journey> GenerateJourneys(
            JourneyPriceRequest request,
            DateTime beginDate,
            AvailabilityRequestType requestType,
            ScheduleAvailabilityType available)
        {
            List<Journey> journeys = new List<Journey>();
            var totalJourneys = requestType == AvailabilityRequestType.AllPrice ? (this.GenerateRandom() % 5) + 1 : 1;
            for (var i = 0; i < totalJourneys; i++)
            {
                Journey journey;
                var journeyTypeRandom = this.GenerateRandom();
                if (journeyTypeRandom > 50)
                {
                    journey = this.GenerateNonStopJourney(request, beginDate);
                }
                else if (journeyTypeRandom > 20)
                {
                    journey = this.GenerateConnectingJourney(request, beginDate);
                }
                else
                {
                    journey = this.GenerateThruJourney(request, beginDate);
                }

                journey.ScheduleType = requestType;
                journeys.Add(journey);
            }

            foreach (var journey in journeys)
            {
                foreach (var pax in request.Pax)
                {
                    if (available == ScheduleAvailabilityType.Available)
                    {
                        journey.Fares.Add(
                                new Fare
                                {
                                    ReferenceId = "FakePssFareRefenreceId",
                                    AvailableSeats = this.GenerateRandom(),
                                    ClassOfService = "N",
                                    FareBasisCode = "NSS",
                                    ProductClass = "NSSTANDARD",
                                    PaxCode = pax.Key,
                                    PromoCode = this.GenerateRandom() > 70 ? "PROMO" : string.Empty,
                                    Charges = new List<Charge>
                                                      {
                                                  new Charge
                                                      {
                                                          Currency = request.Currency,
                                                          Amount = this.GenerateRandom() * 100,
                                                          Code = pax.Key,
                                                          Type = ChargeType.Fare
                                                      },
                                                  new Charge
                                                      {
                                                          Code = "CH1",
                                                          Currency = request.Currency,
                                                          Amount = this.GenerateRandom() * 10,
                                                          Type = ChargeType.Tax
                                                      },
                                                  new Charge
                                                      {
                                                          Code = "CH2",
                                                          Currency = request.Currency,
                                                          Amount = this.GenerateRandom() * 10,
                                                          Type = ChargeType.Tax
                                                      },
                                                  new Charge
                                                      {
                                                          Code = "CH3",
                                                          Currency = request.Currency,
                                                          Amount = this.GenerateRandom() * 10,
                                                          Type = ChargeType.Tax
                                                      }
                                                      }
                                });

                        if (requestType == AvailabilityRequestType.AllPrice)
                        {
                            journey.Fares.Add(
                                new Fare
                                {
                                    ReferenceId = "FakePssFareRefenreceId",
                                    AvailableSeats = this.GenerateRandom(),
                                    ClassOfService = "N",
                                    FareBasisCode = "NSP",
                                    ProductClass = "NSPREMIUM",
                                    PaxCode = pax.Key,
                                    PromoCode = this.GenerateRandom() > 70 ? "PROMO" : string.Empty,
                                    Charges = new List<Charge>
                                                      {
                                                  new Charge
                                                      {
                                                          Currency = request.Currency,
                                                          Amount = this.GenerateRandom() * 100,
                                                          Code = pax.Key,
                                                          Type = ChargeType.Fare
                                                      },
                                                  new Charge
                                                      {
                                                          Code = "CH1",
                                                          Currency = request.Currency,
                                                          Amount = this.GenerateRandom() * 10,
                                                          Type = ChargeType.Tax
                                                      },
                                                  new Charge
                                                      {
                                                          Code = "CH2",
                                                          Currency = request.Currency,
                                                          Amount = this.GenerateRandom() * 10,
                                                          Type = ChargeType.Tax
                                                      },
                                                  new Charge
                                                      {
                                                          Code = "CH3",
                                                          Currency = request.Currency,
                                                          Amount = this.GenerateRandom() * 10,
                                                          Type = ChargeType.Tax
                                                      }
                                                      }
                                });
                            journey.Fares.Add(
                                new Fare
                                {
                                    ReferenceId = "FakePssFareRefenreceId",
                                    AvailableSeats = this.GenerateRandom(),
                                    ClassOfService = "N",
                                    FareBasisCode = "NSB",
                                    ProductClass = "NSBUSINESS",
                                    PaxCode = pax.Key,
                                    PromoCode = this.GenerateRandom() > 70 ? "PROMO" : string.Empty,
                                    Charges = new List<Charge>
                                        {
                                                  new Charge
                                                      {
                                                          Currency = request.Currency,
                                                          Amount = this.GenerateRandom() * 100,
                                                          Code = pax.Key,
                                                          Type = ChargeType.Fare
                                                      },
                                                  new Charge
                                                      {
                                                          Code = "CH1",
                                                          Currency = request.Currency,
                                                          Amount = this.GenerateRandom() * 10,
                                                          Type = ChargeType.Tax
                                                      },
                                                  new Charge
                                                      {
                                                          Code = "CH2",
                                                          Currency = request.Currency,
                                                          Amount = this.GenerateRandom() * 10,
                                                          Type = ChargeType.Tax
                                                      },
                                                  new Charge
                                                      {
                                                          Code = "CH3",
                                                          Currency = request.Currency,
                                                          Amount = this.GenerateRandom() * 10,
                                                          Type = ChargeType.Tax
                                                      }
                                        }
                                });
                        }
                    }
                }
            }

            return journeys;
        }

        private Journey GenerateThruJourney(JourneyPriceRequest request, DateTime currentDate)
        {
            var journey = new Journey
            {
                ReferenceId = $"FakePssJourneyRefenreceId{currentDate.ToShortDateString()}",
                Segments = new List<Segment>
                                        {
                                            new Segment
                                                {
                                                    ReferenceId = "FakePssSegmentRefenreceId",
                                                    Transport = new Transport
                                                                    {
                                                                        Carrier  = new Carrier
                                                                                    {
                                                                                        Code = "NS",
                                                                                        Name = "Newshore"
                                                                                    },
                                                                        Manufacturer = "Airbus",
                                                                        Model = "A320",
                                                                        Name = "CoolPlaneName",
                                                                        Number = "1678",
                                                                        Type = TransportType.Plane
                                                                    },
                                                    Legs = new List<Leg>
                                                            {
                                                                new Leg
                                                                    {
                                                                        Destination = "MID",
                                                                        Origin = request.Origin,
                                                                        DestinationTerminal = "4",
                                                                        Duration = new TimeSpan(2, 0, 0),
                                                                        LegInfo = new LegInfo
                                                                                      {
                                                                                          IsSubjectedToGovernmentApproval = this.GenerateRandom() > 80
                                                                                      },
                                                                        OriginTerminal = "2",
                                                                        STD = currentDate.AddHours(4),
                                                                        STDUTC = currentDate.AddHours(4).ToUniversalTime(),
                                                                        STA = currentDate.AddHours(6),
                                                                        STAUTC = currentDate.AddHours(6).ToUniversalTime(),
                                                                    },
                                                                new Leg
                                                                    {
                                                                        Destination = request.Destination,
                                                                        Origin = "MID",
                                                                        DestinationTerminal = "1",
                                                                        Duration = new TimeSpan(3, 0, 0),
                                                                        LegInfo = new LegInfo
                                                                                      {
                                                                                          IsSubjectedToGovernmentApproval = this.GenerateRandom() > 80
                                                                                      },
                                                                        OriginTerminal = "4",
                                                                        STD = currentDate.AddHours(7),
                                                                        STDUTC = currentDate.AddHours(7).ToUniversalTime(),
                                                                        STA = currentDate.AddHours(10),
                                                                        STAUTC = currentDate.AddHours(10).ToUniversalTime(),
                                                                    }
                                                            }
                                                }
                                        }
            };
            return journey;
        }

        private Journey GenerateConnectingJourney(JourneyPriceRequest request, DateTime currentDate)
        {
            var journey = new Journey
            {
                ReferenceId = $"FakePssJourneyRefenreceId{currentDate.ToShortDateString()}",
                Segments = new List<Segment>
                                        {
                                            new Segment
                                                {
                                                    ReferenceId = "FakePssSegmentRefenreceId1",
                                                    Transport = new Transport
                                                                    {
                                                                        Carrier  = new Carrier
                                                                                    {
                                                                                        Code = "NS",
                                                                                        Name = "Newshore"
                                                                                    },
                                                                        Manufacturer = "Airbus",
                                                                        Model = "A320",
                                                                        Name = "CoolPlaneName",
                                                                        Number = "1678",
                                                                        Type = TransportType.Plane
                                                                    },
                                                    Legs = new List<Leg>
                                                            {
                                                                new Leg
                                                                    {
                                                                        Destination = "MID",
                                                                        Origin = request.Origin,
                                                                        DestinationTerminal = "4",
                                                                        Duration = new TimeSpan(2, 0, 0),
                                                                        LegInfo = new LegInfo
                                                                                        {
                                                                                            IsSubjectedToGovernmentApproval = this.GenerateRandom() > 80
                                                                                        },
                                                                        OriginTerminal = "2",
                                                                        STD = currentDate.AddHours(4),
                                                                        STDUTC = currentDate.AddHours(4).ToUniversalTime(),
                                                                        STA = currentDate.AddHours(6),
                                                                        STAUTC = currentDate.AddHours(6).ToUniversalTime(),
                                                                    }
                                                            }
                                                },
                                            new Segment
                                                {
                                                    ReferenceId = "FakePssSegmentRefenreceId2",
                                                    Transport = new Transport
                                                                    {
                                                                        Carrier  = new Carrier
                                                                                    {
                                                                                        Code = "NS",
                                                                                        Name = "Newshore"
                                                                                    },
                                                                        Manufacturer = "Airbus",
                                                                        Model = "A320",
                                                                        Name = "YetAnotherCoolPlaneName",
                                                                        Number = "1680",
                                                                        Type = TransportType.Plane
                                                                    },
                                                    Legs = new List<Leg>
                                                            {
                                                                new Leg
                                                                    {
                                                                        Destination = request.Destination,
                                                                        Origin = "MID",
                                                                        DestinationTerminal = "3",
                                                                        Duration = new TimeSpan(1, 0, 0),
                                                                        LegInfo = new LegInfo
                                                                                        {
                                                                                            IsSubjectedToGovernmentApproval = this.GenerateRandom() > 80
                                                                                        },
                                                                        OriginTerminal = "4",
                                                                        STD = currentDate.AddHours(7),
                                                                        STDUTC = currentDate.AddHours(7).ToUniversalTime(),
                                                                        STA = currentDate.AddHours(8),
                                                                        STAUTC = currentDate.AddHours(8).ToUniversalTime(),
                                                                    }
                                                            }
                                                }
                                        }
            };
            return journey;
        }

        private Journey GenerateNonStopJourney(JourneyPriceRequest request, DateTime currentDate)
        {
            var journey = new Journey
                              {
                                    ReferenceId = $"FakePssJourneyRefenreceId{currentDate.ToShortDateString()}",
                                    Segments = new List<Segment>
                                        {
                                            new Segment
                                                {
                                                    ReferenceId = "FakePssSegmentRefenreceId",
                                                    Transport = new Transport
                                                                    {
                                                                        Carrier  = new Carrier
                                                                                    {
                                                                                        Code = "NS",
                                                                                        Name = "Newshore"
                                                                                    },
                                                                        Manufacturer = "Airbus",
                                                                        Model = "A320",
                                                                        Name = "CoolPlaneName",
                                                                        Number = "1678",
                                                                        Type = TransportType.Plane
                                                                    },
                                                    Legs = new List<Leg>
                                                            {
                                                                new Leg
                                                                    {
                                                                        Destination = request.Destination,
                                                                        Origin = request.Origin,
                                                                        DestinationTerminal = "4",
                                                                        Duration = new TimeSpan(2, 0, 0),
                                                                        LegInfo = new LegInfo
                                                                                        {
                                                                                            IsSubjectedToGovernmentApproval = this.GenerateRandom() > 80
                                                                                        },
                                                                        OriginTerminal = "2",
                                                                        STD = currentDate.AddHours(4),
                                                                        STDUTC = currentDate.AddHours(4).ToUniversalTime(),
                                                                        STA = currentDate.AddHours(6),
                                                                        STAUTC = currentDate.AddHours(6).ToUniversalTime(),
                                                                    }
                                                            }
                                                }
                                        }
                              };
            return journey;
        }

        private int GenerateRandom()
        {
            Thread.Sleep(5);
            return this.random.Next(1, 100);
        }
    }
}