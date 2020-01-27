namespace NS.Booking.Domain.Tests.Journey.Models
{
    using System.Linq;

    using Newshore.Core.NativeObjects.Extensions;

    using NS.Booking.Domain.Journey.Exceptions;
    using NS.Booking.Domain.Journey.Models;

    using NUnit.Framework;

    [TestFixture]
    public class JourneyTests
    {
        private Journey validJourney;
        private Journey invalidJourney;

        [SetUp]
        public void Setup()
        {
            this.invalidJourney = new Journey();
            this.validJourney = new MockValidJourney().Journey;
        }

        [Test]
        public void ShouldReturnNewInvalidJourney()
        {
            Assert.Throws<InvalidJourneyInformationException>(() =>
            {
                this.invalidJourney.Validate();
            });
        }

        [Test]
        public void ShouldReturnNewValidJourney()
        {
            this.validJourney.Validate();
        }

        [Test]
        public void ShouldReturnValidId()
        {
            this.validJourney.ReferenceId = "ReferenceId";
            var value = string.Join("~", this.validJourney.Segments.Select(segment => segment.Id)) + "~" + this.validJourney.ReferenceId.EncodeHexadecimal();

            Assert.AreEqual(this.validJourney.Id, value.EncodeHexadecimal());
        }

        [Test]
        public void OriginReturnsFirstSegmentOrigin()
        {
            Assert.AreEqual(this.validJourney.Origin, this.validJourney.Segments.First().Origin);
        }

        [Test]
        public void DestinationReturnsLastSegmentDestination()
        {
            Assert.AreEqual(this.validJourney.Destination, this.validJourney.Segments.Last().Destination);
        }

        [Test]
        public void StdReturnsFirstSegmentStd()
        {
            Assert.AreEqual(this.validJourney.STD, this.validJourney.Segments.First().STD);
        }

        [Test]
        public void StdUtcReturnsFirstSegmentStdUtc()
        {
            Assert.AreEqual(this.validJourney.STDUTC, this.validJourney.Segments.First().STDUTC);
        }

        [Test]
        public void StaReturnsLastSegmentSta()
        {
            Assert.AreEqual(this.validJourney.STA, this.validJourney.Segments.Last().STA);
        }

        [Test]
        public void StaUtcReturnsLastSegmentStaUtc()
        {
            Assert.AreEqual(this.validJourney.STAUTC, this.validJourney.Segments.Last().STAUTC);
        }
    }
}
