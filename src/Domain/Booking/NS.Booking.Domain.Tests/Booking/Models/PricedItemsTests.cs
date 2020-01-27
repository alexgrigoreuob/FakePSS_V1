using NS.Booking.Common.Domain.PricedItem.Models;

namespace NS.Booking.Domain.Tests.Booking.Models
{
    using NS.Booking.Common.Domain.Charge.Enums;
    using NS.Booking.Common.Domain.Charge.Models;

    using NUnit.Framework;

    [TestFixture]
    public class PricedItemsTests
    {
        private PricedItem pricedItem;
        [SetUp]
        public void SetUp()
        {
            pricedItem = new PricedItem();
        }

        [TestCase(2, 1, 1)]
        [TestCase(3, 2, 1)]
        [TestCase(3, 0, 3)]
        [TestCase(0, 1, -1)]
        public void TotalAmountIsCalculatedCorrectlyWhenThereAreDiscounts(int totalCost, int totalDiscount, int totalAmount)
        {
            for (var i = 0; i < totalCost; i++)
            {
                pricedItem.Charges.Add(new Charge
                                           {
                                               Amount = 1,
                                               Type = ChargeType.Fare
                                           });
            }

            for (var i = 0; i < totalDiscount; i++)
            {
                pricedItem.Charges.Add(new Charge
                                           {
                                               Amount = 1,
                                               Type = ChargeType.Discount
                                           });
            }
            
            Assert.AreEqual(pricedItem.TotalAmount, totalAmount);
        }

        [Test]
        public void CurrencyIsNotSetWhenNoCharge()
        {
            Assert.AreEqual(pricedItem.Currency, string.Empty);
        }

        [Test]
        public void CurrencyIsSetWhenThereAreCharges()
        {
            pricedItem.Charges.Add(new Charge
                                       {
                                           Currency = "Currency"
            });

            Assert.AreEqual(this.pricedItem.Currency, "Currency");
        }
    }
}