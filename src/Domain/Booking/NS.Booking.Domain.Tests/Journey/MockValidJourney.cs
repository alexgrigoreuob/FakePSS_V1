namespace NS.Booking.Domain.Tests.Journey
{
    using NS.Booking.Domain.Journey.Models;
    using System;
    using System.Collections.Generic;

    public class MockValidJourney
    {
        public MockValidJourney()
        {
            Journey = new Journey
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        Legs = new List<Leg>
                        {
                            new Leg
                                {
                                    Origin = "BCN",
                                    Destination = "MID",
                                    STD = DateTime.Today,
                                    STDUTC = DateTime.Today.AddHours(-1),
                                    STA = DateTime.Today.AddHours(12),
                                    STAUTC = DateTime.Today.AddDays(1).AddHours(-1)
                                },
                            new Leg
                                {
                                    Origin = "MID",
                                    Destination = "MZL",
                                    STD = DateTime.Today.AddHours(12),
                                    STDUTC = DateTime.Today.AddHours(11),
                                    STA = DateTime.Today.AddDays(1),
                                    STAUTC = DateTime.Today.AddDays(1).AddHours(-1)
                                }
                        },
                        Transport = new Transport
                        {
                            Carrier = new Carrier { Code = "NS", Name = "Newshore" },
                            Number = "1234"
                        },
                        ReferenceId = "NS~600~~2019-01-01"
                    },
                    new Segment
                    {
                        Legs = new List<Leg>
                        {
                            new Leg
                            {
                                Origin = "MZL",
                                Destination = "BCN",
                                STD = DateTime.Today.AddHours(1),
                                STDUTC = DateTime.Today,
                                STA = DateTime.Today.AddDays(1).AddHours(1),
                                STAUTC = DateTime.Today.AddDays(1)
                            }
                        },
                        Transport = new Transport
                        {
                            Carrier = new Carrier { Code = "NS", Name = "Newshore" },
                            Number = "1234"
                        },
                        ReferenceId = string.Empty
                    }
                }
            };
        }

        public Journey Journey { get; set; }
    }
}
