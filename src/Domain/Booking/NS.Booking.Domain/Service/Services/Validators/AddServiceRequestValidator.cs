namespace NS.Booking.Domain.Service.Services.Validators
{
    using System;

    using Conditions;

    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Service.Exceptions;
    using NS.Booking.Domain.Service.Models.Requests;

    public class AddServiceRequestValidator : IValidator<AddServiceRequest>
    {
        public void Validate(AddServiceRequest valueToValidate)
        {
            try
            {
                ValidateRequires(valueToValidate);
            }
            catch (Exception)
            {
                throw new InvalidAddServiceRequestInformationException();
            }
        }

        private static void ValidateRequires(AddServiceRequest serviceToValidate)
        {
            serviceToValidate.ServiceSellKey.Requires().IsNotNullOrEmpty();
            serviceToValidate.Code.Requires().IsNotNullOrEmpty();
        }
    }
}
