namespace NS.Booking.Domain.Tests.Pax.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Common.Domain.Person.Enums;
    using NS.Booking.Common.Domain.Person.Models;
    using NS.Booking.Domain.Pax.Enums;
    using NS.Booking.Domain.Pax.Exceptions;
    using NS.Booking.Domain.Pax.Models;
    using NS.Booking.Domain.Pax.Services.Validators;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PaxValidatorTests
    {
        private IValidator<Pax> _validator;
        private Pax _validPax;

        [SetUp]
        public void Setup()
        {
            _validator = new PaxValidator();
            _validPax = new Pax
            {
                Name = new PersonName
                {
                    First = "newshore",
                    Last = "test",
                    Title = TitleType.MSS
                },
                Type = new PaxTypeInfo
                {
                    Category = PaxCategoryType.Adult,
                    Code = "ADT"
                },
                PersonInfo = new PersonInfo
                {
                    DateOfBirth = DateTime.Today,
                }
            };
        }

        [Test]
        public void ThrowsWhenNullContact()
        {
            Assert.Throws<InvalidPaxInformationException>(() =>
            {
                _validator.Validate(null);
            });
        }

        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("newshore", null)]
        [TestCase("", "newshore")]
        public void ThrowsWhenInvalidNameData(string firstName, string lastName)
        {
            this._validPax.Name.First = firstName;
            this._validPax.Name.Last = lastName;

            Assert.Throws<InvalidPaxInformationException>(() =>
            {
                this._validator.Validate(this._validPax);
            });
        }

        [Test]
        public void ThrowsWhenInvalidDateOfBirth()
        {
            this._validPax.PersonInfo.DateOfBirth = new DateTime();
            Assert.Throws<InvalidPaxInformationException>(() =>
            {
                _validator.Validate(this._validPax);
            });
        }

        [Test]
        public void ThrowsWhenInvalidTitleType()
        {
            this._validPax.Name.Title = TitleType.Default;
            Assert.Throws<InvalidPaxInformationException>(() =>
            {
                _validator.Validate(this._validPax);
            });
        }

        [Test]
        public void DoesNotThrowWhenPaxIsValid()
        {
            Assert.DoesNotThrow(() => _validator.Validate(_validPax));
        }
    }
}
