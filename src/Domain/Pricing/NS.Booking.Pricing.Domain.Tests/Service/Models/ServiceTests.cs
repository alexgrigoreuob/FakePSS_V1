namespace NS.Booking.Pricing.Domain.Tests.Service.Models
{
    using NS.Booking.Common.Domain.Service.Enums;
    using NS.Booking.Pricing.Domain.Service.Models;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    using NS.Booking.Common.Domain.Charge.Enums;
    using NS.Booking.Common.Domain.Charge.Models;

    [TestFixture]
    public class ServiceTests
    {
        [Test]
        public void DifferentEntitiesGenerateDifferentIds()
        {
            var serviceOne = new Service
            {
                Info = new ServiceInfo
                {
                    Code = "BAG01",
                    Name = "Bag25kg",
                    Type = ServiceType.Baggage
                },
                Availability = new List<ServiceAvailability>
                {
                    new ServiceAvailability
                    {
                        SellKey = "ABC123"
                    },
                    new ServiceAvailability
                    {
                        SellKey = "ABC456"
                    }
                }
            };

            var serviceTwo = new Service
            {
                Info = new ServiceInfo
                {
                    Code = "BAG01",
                    Name = "Bag25kg",
                    Type = ServiceType.Baggage
                },
                Availability = new List<ServiceAvailability>
                {
                    new ServiceAvailability
                    {
                        SellKey = "ABC789"
                    }
                }
            };

            Assert.AreNotEqual(serviceTwo.Id, serviceOne.Id);
        }

        [TestCase("1", "2", -1)]
        [TestCase("1", "1", 0)]
        [TestCase("1", "0", 1)]
        [TestCase("1,2,3", "0", 6)]
        [TestCase("1,2,3", "3,2", 1)]
        [TestCase("0", "0", 0)]
        public void GetTotalAmount(string price, string discount, int expectedResult)
        {
            var charges = price.Split(',').Select(
                x => new Charge { Amount = int.Parse(x), Code = "TEST", Currency = "TEST", Type = ChargeType.Service });
            var discounts = discount.Split(',').Where(x => x != "0").Select(
                x => new Charge { Amount = int.Parse(x), Code = "TEST", Currency = "TEST", Type = ChargeType.Discount });
            var service = new Service();
            service.Charges.AddRange(charges);
            service.Charges.AddRange(discounts);

            Assert.AreEqual(expectedResult, service.GetTotalAmount());
        }
    }
}
