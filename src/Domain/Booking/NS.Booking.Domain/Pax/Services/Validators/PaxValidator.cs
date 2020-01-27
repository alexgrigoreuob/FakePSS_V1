
namespace NS.Booking.Domain.Pax.Services.Validators
{
    using Conditions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Common.Domain.Person.Enums;
    using NS.Booking.Common.Domain.Person.Models;
    using NS.Booking.Domain.Pax.Exceptions;
    using NS.Booking.Domain.Pax.Models;
    using System;
    using System.Collections.Generic;

    public class PaxValidator : IValidator<Pax>
    {
        public void Validate(Pax valueToValidate)
        {
            try
            {
                ValidateRequires(valueToValidate);
                ValidateAddress(valueToValidate.Address);
                ValidateDocuments(valueToValidate.Documents);
            }
            catch (Exception)
            {
                throw new InvalidPaxInformationException();
            }
        }
        
        private void ValidateRequires(Pax valueToValidate)
        {
            valueToValidate.Requires().IsNotNull();
            valueToValidate.Name.Requires().IsNotNull();
            valueToValidate.Name.Title.Requires().IsNotEqualTo(TitleType.Default);
            valueToValidate.Name.First.Requires().IsNotNullOrEmpty();
            valueToValidate.Name.Last.Requires().IsNotNullOrEmpty();
            valueToValidate.PersonInfo.Requires().IsNotNull();
            valueToValidate.PersonInfo.DateOfBirth.Requires().IsGreaterThan(DateTime.MinValue);
            valueToValidate.Type.Requires().IsNotNull();
            valueToValidate.Type.Code.Requires().IsNotNullOrEmpty();
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
