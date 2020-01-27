namespace NS.Booking.Domain.Tests.Contact.Models
{
    using Newshore.Core.NativeObjects.Extensions;
    using NS.Booking.Domain.Contact.Enums;
    using NS.Booking.Domain.Contact.Exceptions;
    using NS.Booking.Domain.Contact.Models;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    using NS.Booking.Common.Domain.Person.Enums;
    using NS.Booking.Common.Domain.Person.Models;

    [TestFixture]
    public class ContactTests
    {
        private Contact _validContact;
        private Contact _invalidContact;

        [SetUp]
        public void Setup()
        {
            _invalidContact = new Contact();
            _validContact = new Contact
            {
                Name = new PersonName
                {
                    First = "newshore",
                    Last = "test",
                    Title = TitleType.MR
                },
                Channels = new List<PersonCommunicationChannel>
                {
                    new PersonCommunicationChannel
                    {
                        Info = "1234",
                        Type = ChannelType.SMS
                    }
                },
                Type = ContactType.Booking
            };
        }

        [Test]
        public void ShouldReturnNewInvalidContact()
        {
            Assert.Throws<InvalidContactInformationException>(() =>
            {
                _invalidContact.Validate();
            });
        }

        [Test]
        public void ShouldReturnNewValidContact()
        {
            _validContact.Validate();
        }

        [Test]
        public void ShouldReturnValidIdContact()
        {
            var info = _validContact.Channels.Any() ? _validContact.Channels.First().Info : string.Empty;
            var value = $"{this._validContact.Name.First}~{this._validContact.Name.Last}~{this._validContact.Type}~{info}";
            
            Assert.AreEqual(_validContact.Id, value.EncodeHexadecimal());
        }
    }
}
