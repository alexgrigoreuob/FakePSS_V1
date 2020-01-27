namespace NS.Booking.Domain.Contact.Services.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using Conditions;

    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Common.Domain.Person.Enums;
    using NS.Booking.Common.Domain.Person.Models;
    using NS.Booking.Domain.Contact.Exceptions;
    using NS.Booking.Domain.Contact.Models;

    public class ContactValidator : IValidator<Contact>
    {
        public void Validate(Contact valueToValidate)
        {
            try
            {
                ValidateRequires(valueToValidate);
                ValidateChannels(valueToValidate.Channels);
                ValidateAddress(valueToValidate.Address);
                ValidateDocuments(valueToValidate.Documents);
            }
            catch (Exception)
            {
                throw new InvalidContactInformationException();
            }
        }
        
        private void ValidateRequires(Contact valueToValidate)
        {
            valueToValidate.Requires().IsNotNull();
            valueToValidate.Name.Requires().IsNotNull();
            valueToValidate.Name.Title.Requires().IsNotEqualTo(TitleType.Default);
            valueToValidate.Name.First.Requires().IsNotNullOrEmpty();
            valueToValidate.Name.Last.Requires().IsNotNullOrEmpty();
            valueToValidate.Channels.Requires().IsNotNull().IsNotEmpty();
        }

        private void ValidateChannels(List<PersonCommunicationChannel> channels)
        {
            var emailTester = new Regex(@"^\w+([\.\-_]?(\w+)?)*@([a-zA-Z\-]+)*(\.\w{2,4})+$", RegexOptions.IgnoreCase);

            channels.ForEach(x => {
                x.Info.Requires().IsNotNullOrEmpty();
                switch (x.Type)
                {
                    case ChannelType.Email:
                        if (!emailTester.IsMatch(x.Info))
                        {
                            throw new InvalidContactInformationException();
                        }
                        break;
                    case ChannelType.SMS:
                        ValidatePhoneNumber(x.Info);
                        break;
                    case ChannelType.Phone:
                        ValidatePhoneNumber(x.Info);
                        break;
                    default:
                        break;
                }
            });
        }

        private void ValidatePhoneNumber(string info)
        {
            if (!long.TryParse(info, out long n))
            {
                throw new InvalidContactInformationException();
            }
        }

        private void ValidateAddress(PersonAddress address)
        {
            if (address != null)
            {
                address.AddressLine.Requires().IsNotNullOrEmpty();
            }
        }

        private void ValidateDocuments(List<PersonDocument> documents)
        {
            if (documents != null)
            {
                documents.ForEach(x =>
                {
                    x.Number.Requires().IsNotNullOrEmpty();
                });
            }
        }
    }
}
