namespace NS.Booking.Domain.Tests.Journey.Models
{
    using System.Linq;

    using Newshore.Core.NativeObjects.Extensions;

    using NS.Booking.Domain.Journey.Models;

    using NUnit.Framework;

    [TestFixture]
    public class SegmentTests
    {
        private Segment validSegment;

        [SetUp]
        public void Setup()
        {
            validSegment = new MockValidJourney().Journey.Segments.First();
        }

        [Test]
        public void ShouldReturnValidId()
        {
            var expected = $"{validSegment.Legs.First().Origin}~{validSegment.Legs.Last().Destination}~{validSegment.Transport.Number}~" +
                $"{validSegment.Transport.Carrier.Code}~{validSegment.Legs.First().STD:yyyy-MM-dd}~{validSegment.ReferenceId.EncodeHexadecimal()}";

            Assert.AreEqual(validSegment.Id, expected.EncodeHexadecimal());
        }

        [Test]
        public void ShouldReturnValidIdSegmentWhenReferenceIdIsEmpty()
        {
            validSegment.ReferenceId = string.Empty;
            var expected = $"{validSegment.Legs.First().Origin}~{validSegment.Legs.Last().Destination}~{validSegment.Transport.Number}~" +
                $"{validSegment.Transport.Carrier.Code}~{validSegment.Legs.First().STD:yyyy-MM-dd}~";

            Assert.AreEqual(validSegment.Id, expected.EncodeHexadecimal());
        }

        [Test]
        public void OriginReturnsFirstLegOrigin()
        {
            Assert.AreEqual(this.validSegment.Origin, this.validSegment.Legs.First().Origin);
        }

        [Test]
        public void DestinationReturnsLastLegDestination()
        {
            Assert.AreEqual(this.validSegment.Destination, this.validSegment.Legs.Last().Destination);
        }

        [Test]
        public void StdReturnsFirstLegStd()
        {
            Assert.AreEqual(this.validSegment.STD, this.validSegment.Legs.First().STD);
        }

        [Test]
        public void StdUtcReturnsFirstLegStdUtc()
        {
            Assert.AreEqual(this.validSegment.STDUTC, this.validSegment.Legs.First().STDUTC);
        }

        [Test]
        public void StaReturnsLastLegSta()
        {
            Assert.AreEqual(this.validSegment.STA, this.validSegment.Legs.Last().STA);
        }

        [Test]
        public void StaUtcReturnsLastLegStaUtc()
        {
            Assert.AreEqual(this.validSegment.STAUTC, this.validSegment.Legs.Last().STAUTC);
        }
    }
}
