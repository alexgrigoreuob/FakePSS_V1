namespace NS.Booking.Domain.Tests.Pax.Models
{
    using Newshore.Core.NativeObjects.Extensions;
    using NS.Booking.Common.Domain.Person.Enums;
    using NS.Booking.Common.Domain.Person.Models;
    using NS.Booking.Domain.Pax.Enums;
    using NS.Booking.Domain.Pax.Exceptions;
    using NS.Booking.Domain.Pax.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PaxTests
    {
        private Pax _validPax;
        private Pax _invalidPax;

        [SetUp]
        public void Setup()
        {
            _invalidPax = new Pax();
            _validPax = new Pax
            {
                ReferenceId = "0",
                Name = new PersonName
                {
                    First = "newshore",
                    Last = "test",
                    Title = TitleType.MR
                },
                Type = new PaxTypeInfo
                {
                    Category = PaxCategoryType.Adult,
                    Code = "ADT"
                },
                Address = new PersonAddress
                {
                    AddressLine = "AddressLine"
                },
                Documents = new List<PersonDocument>
                {
                    new PersonDocument
                        {
                            Number = "Number"
                        }
                },
                PersonInfo = new PersonInfo
                {
                    DateOfBirth = DateTime.Today,
                }
            };
        }

        [Test]
        public void ShouldReturnNewInvalidPax()
        {
            Assert.Throws<InvalidPaxInformationException>(() =>
            {
                _invalidPax.Validate();
            });
        }

        [Test]
        public void ShouldReturnNewValidPax()
        {
            _validPax.Validate();
        }

        [Test]
        public void ShouldReturnValidIdPax()
        {
            var value = string.Format("{0}~{1}~{2}~{3}",
                _validPax.Name.First, _validPax.Name.Last, _validPax.PersonInfo.DateOfBirth.ToUniversalTime().ToString("yyyy-MM-dd"), this._validPax.ReferenceId.EncodeHexadecimal());

            Assert.AreEqual(_validPax.Id, value.EncodeHexadecimal());
        }

        [Test]
        public void ReturnsEmptyIdWhenNoBasicInfoAdded()
        {
            _validPax.Name = new PersonName();
            _validPax.ReferenceId = string.Empty;
            Assert.AreEqual(_validPax.Id, string.Empty);
        }
    }
}
