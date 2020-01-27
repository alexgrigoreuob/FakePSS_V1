namespace NS.Booking.Domain.Tests.Journey.Models
{
    using Newshore.Core.NativeObjects.Extensions;
    using NS.Booking.Common.Domain.Charge.Models;
    using NS.Booking.Domain.Journey.Models;

    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class FareTests
    {
        private Fare fare;
        private List<Charge> charges;

        [SetUp]
        public void Setup()
        {
            charges = new List<Charge>
            {
                new Charge
                {
                    Amount=800000,
                    Type=Common.Domain.Charge.Enums.ChargeType.Fare,
                    Code="Fare"
                },
                new Charge
                {
                    Amount=20000,
                    Type=Common.Domain.Charge.Enums.ChargeType.Tax,
                    Code="Tax"
                },
                new Charge
                {
                    Amount=80000,
                    Type=Common.Domain.Charge.Enums.ChargeType.Discount,
                    Code="PromotionalDiscount"
                }
            };

            fare = new Fare
            {
                ReferenceId = "ReferenceId",
                FareBasisCode = "FareBasisCode",
                ClassOfService = "ClassOfService",
                PaxCode = "PaxCode",
                ProductClass = "ProductClass",
                PromoCode="Promo",
                Charges = charges
            };

        }

        [Test]
        public void ReturnTotalAmountOperation()
        {
            Assert.AreEqual(740000, fare.TotalAmount);
        }

        [Test]
        public void ShouldReturnValidId()
        {
            var expected = $"{fare.ProductClass}~{fare.FareBasisCode}~{fare.ClassOfService}~{fare.PaxCode}~{fare.PromoCode}~{fare.ReferenceId.EncodeHexadecimal()}";

            Assert.AreEqual(fare.Id, expected.EncodeHexadecimal());
        }

        [Test]
        public void ShouldReturnValidIdWhenReferenceIdIsEmpty()
        {
            fare.ReferenceId = string.Empty;

            var expected = $"{fare.ProductClass}~{fare.FareBasisCode}~{fare.ClassOfService}~{fare.PaxCode}~{fare.PromoCode}~";

            Assert.AreEqual(fare.Id, expected.EncodeHexadecimal());
        }
    }
}
