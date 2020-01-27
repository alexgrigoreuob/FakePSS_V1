namespace NS.Booking.Resources.Domain.Tests.SeatMap.Models
{
    using Newshore.Core.NativeObjects.Extensions;
    using NS.Booking.Resources.Domain.SeatMap.Models;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class TransportTests
    {
        [Test]
        public void ValidEntityGeneratesValidId()
        {
            var transport = new Transport
            {
                Segment = new Segment() { SegmentId = "123ABC" },
                Sufix = "A330",
                Type = "Tipo",
                Decks = new List<Deck>() {
                    new Deck(){
                        Cabins = new List<Cabin>(){
                            
                        },
                        Number = 1
                    }
                }
            };
            var expectedId = $"{"123ABC"}~{"Tipo"}~{"A330"}";
            Assert.AreEqual(transport.Id, expectedId.EncodeHexadecimal());
        }
    }
}
