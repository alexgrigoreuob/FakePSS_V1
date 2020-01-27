namespace NS.Booking.Domain.Tests.Contact.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Common.Domain.Person.Enums;
    using NS.Booking.Common.Domain.Person.Models;
    using NS.Booking.Domain.Contact.Enums;
    using NS.Booking.Domain.Contact.Exceptions;
    using NS.Booking.Domain.Contact.Models;
    using NS.Booking.Domain.Contact.Services.Validators;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ContactValidatorTests
    {
        private IValidator<Contact> validator;
        private Contact validContact;

        [SetUp]
        public void Setup()
        {
            this.validator = new ContactValidator();
            this.validContact = new Contact
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
                        Info = "12341243123412",
                        Type = ChannelType.SMS
                    },
                    new PersonCommunicationChannel
                        {
                            Info = "asd@asd.asd",
                            Type = ChannelType.Email
                        }
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
                Type = ContactType.Booking
            };
        }

        [Test]
        public void ThrowsWhenNullContact()
        {
            Assert.Throws<InvalidContactInformationException>(() =>
                {
                    this.validator.Validate(null);
                });
        }

        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("newshore", null)]
        [TestCase("", "newshore")]
        public void ThrowsWhenInvalidNameData(string firstName, string lastName)
        {
            this.validContact.Name.First = firstName;
            this.validContact.Name.Last = lastName;

            Assert.Throws<InvalidContactInformationException>(() =>
                {
                    this.validator.Validate(this.validContact);
                });
        }

        [Test]
        public void ThrowsWhenNoChannel()
        {
            this.validContact.Channels = new List<PersonCommunicationChannel>();
            Assert.Throws<InvalidContactInformationException>(() =>
                {
                    this.validator.Validate(this.validContact);
                });
        }

        [Test]
        public void ThrowsWhenAddressLineIsNotValid()
        {
            this.validContact.Address.AddressLine = string.Empty;
            Assert.Throws<InvalidContactInformationException>(() =>
                {
                    this.validator.Validate(this.validContact);
                });
        }

        [Test]
        public void ThrowsWhenInvalidTitleType()
        {
            this.validContact.Name.Title = TitleType.Default;
            Assert.Throws<InvalidContactInformationException>(() =>
            {
                this.validator.Validate(this.validContact);
            });
        }

        [Test]
        public void ThrowsWhenDocumentNumberIsNotValid()
        {
            this.validContact.Documents.First().Number = string.Empty;
            Assert.Throws<InvalidContactInformationException>(() =>
                {
                    this.validator.Validate(this.validContact);
                });
        }

        [TestCase("asd_asdasd.asd")]
        [TestCase("asd_@asdsd")]
        [TestCase("@asd-asd.asd")]
        [TestCase("asd_asd_@asd-asd.")]
        public void ThrowsWhenInvalidEmil(string email)
        {
            this.validContact.Documents.First().Number = string.Empty;
            Assert.Throws<InvalidContactInformationException>(() =>
                {
                    this.validator.Validate(this.validContact);
                });
        }

        [TestCase("asd_asd@asd.asd")]
        [TestCase("asd_@asd.asd")]
        [TestCase("asd@asd-asd.asd")]
        [TestCase("asd_asd_@asd-asd.asd")]
        [TestCase("asd_asd_@asd-asd.asd")]
        [TestCase("roger-sole-@new-shore.es")]
        [TestCase("roger-sole@newshore.es")]
        [TestCase("rogersole-@newshore.es")]
        [TestCase("rogersole@new-shore.es")]
        [TestCase("m_w_@gmail.com")]
        [TestCase("b_c_@yahoo.com")]
        [TestCase("info@continental-travels.com")]
        [TestCase("___@continental-travels.com")]

        public void DoesNotThrowWhenContactIsValid(string email)
        {
            var emailChannel = this.validContact.Channels.First(x => x.Type == ChannelType.Email);
            emailChannel.Info = email;
            Assert.DoesNotThrow(() => this.validator.Validate(this.validContact));
        }
    }
}
