namespace NS.Booking.Pricing.Domain.Tests.Journey.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newshore.Core.NativeObjects.Extensions;

    using NS.Booking.Pricing.Domain.Journey.Models;

    using NUnit.Framework;

    [TestFixture]
    public class JourneyTests
    {
        [Test]
        public void ValidEntityGeneratesValidId()
        {
            var journey = new Journey
            {
                ReferenceId = "ReferenceId",
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        ReferenceId = "ReferenceId1",
                        Legs = new List<Leg>
                        {
                            new Leg
                            {
                                Origin = "Origin1",
                                Destination = "Destination1",
                                STD = new DateTime(2050, 10, 12)
                            }
                        },
                        Transport = new Transport {
                            Number = "Number1",
                            Carrier = new Carrier
                            {
                                Code = "NS"
                            }
                        }
                    },
                    new Segment
                    {
                        ReferenceId = "ReferenceId2",
                        Legs = new List<Leg>
                        {
                            new Leg
                            {
                                Origin = "Origin2",
                                Destination = "Destination2",
                                STD = new DateTime(2150, 10, 12)
                            }
                        },
                        Transport = new Transport
                        {
                            Number = "Number2",
                            Carrier = new Carrier
                            {
                                Code = "NS"
                            }
                        }
                    }
                }
            };
            var expectedId = (string.Join("~", journey.Segments.Select(segment => segment.Id)) +
                "~" + journey.ReferenceId.EncodeHexadecimal()).EncodeHexadecimal();
            Assert.AreEqual(journey.Id, expectedId);
        }
    }
}