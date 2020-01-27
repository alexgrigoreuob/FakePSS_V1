namespace NS.Booking.Domain.Tests.Fee.Services.Validators
{
    using NS.Booking.Domain.Fee.Exceptions;
    using NS.Booking.Domain.Fee.Models.Requests;
    using NS.Booking.Domain.Fee.Services.Validators;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class AddFeeRequestValidatorTests
    {
        private AddFeeRequestValidator _sut;
        private AddFeeRequest _validRequest;
        private AddFeeRequest _emptyRequest;

        [SetUp]
        public void SetUp()
        {
            this._sut = new AddFeeRequestValidator();
            _validRequest = new AddFeeRequest
            {
                Code = "PLS",
                FeeSellKey = "ABC123",
                PaxId = "AB1234",
                SellKey = "657#$%"
            };

            this._emptyRequest = new AddFeeRequest
            {

            };
        }

        [Test]
        public void ThrowsWhenServiceTypesEmpty()
        {
            Assert.Throws<InvalidAddFeeRequestException>(() => this._sut.Validate(this._emptyRequest));
        }

        [Test]
        public void ThrowsWhenServiceTypesNull()
        {
            var nullRequest = new AddFeeRequest();
            Assert.Throws<InvalidAddFeeRequestException>(() => this._sut.Validate(nullRequest));
        }

        [Test]
        public void DoesNotThrowWhenModelIsValid()
        {
            Assert.DoesNotThrow(() => this._sut.Validate(this._validRequest));
        }
    }
}
