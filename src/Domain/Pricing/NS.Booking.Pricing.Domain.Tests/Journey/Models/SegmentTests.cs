namespace NS.Booking.Pricing.Domain.Tests.Journey.Models
{
    using Newshore.Core.NativeObjects.Extensions;
    using NS.Booking.Pricing.Domain.Journey.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class SegmentTests
    {
        [Test]
        public void ValidEntityGeneratesValidId()
        {
            var segment = new Segment
            {
                ReferenceId = "ReferenceId",
                Legs = new List<Leg>
                {
                    new Leg
                    {
                        Origin = "Origin1",
                        Destination = "Destination1",
                        STD = new DateTime(2050, 10, 12)
                    },
                    new Leg
                    {
                        Origin = "Origin2",
                        Destination = "Destination2"
                    }
                },
                Transport = new Transport {
                    Number = "Number",
                    Carrier = new Carrier
                    {
                        Code = "NS"
                    }
                }
            };
            var expectedId =
                $"{segment.Legs.First().Origin}~{segment.Legs.Last().Destination}~{segment.Transport.Number}~" +
                $"{segment.Transport.Carrier.Code}~{segment.Legs.First().STD:yyyy-MM-dd}~{segment.ReferenceId.EncodeHexadecimal()}";
            Assert.AreEqual(segment.Id, expectedId.EncodeHexadecimal());
        }
    }
}