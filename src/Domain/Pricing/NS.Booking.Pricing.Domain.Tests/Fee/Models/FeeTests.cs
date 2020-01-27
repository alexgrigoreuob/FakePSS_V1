namespace NS.Booking.Pricing.Domain.Tests.Fee.Models
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    [TestFixture]
    public class FeeTests
    {
        [Test]
        public void DifferentEntitiesGenerateDifferentIds()
        {
            var feeOne = new NS.Booking.Pricing.Domain.Fee.Models.Fee
            {
                Code = "PLE",
                PaxId = "AB123",
                ReferenceId = "ABC123",
                SellType = Common.Domain.PricedItem.Enums.ProductScopeType.PerPaxJourney,
                Charges = new List<Common.Domain.Charge.Models.Charge>()
            };

            var feeTwo = new NS.Booking.Pricing.Domain.Fee.Models.Fee
            {
                Code = "PLE",
                PaxId = "AB124",
                ReferenceId = "ABC1233",
                SellType = Common.Domain.PricedItem.Enums.ProductScopeType.PerPaxJourney,
                Charges = new List<Common.Domain.Charge.Models.Charge>()
            };

            Assert.AreNotEqual(feeOne.ReferenceId, feeTwo.ReferenceId);
        }
    }
}
