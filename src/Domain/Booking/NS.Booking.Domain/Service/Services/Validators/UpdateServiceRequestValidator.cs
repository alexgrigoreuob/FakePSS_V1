using Conditions;
using NS.Booking.Common.Domain.Common.Validators;
using NS.Booking.Domain.Service.Exceptions;
using NS.Booking.Domain.Service.Models.Requests;
using System;

namespace NS.Booking.Domain.Service.Services.Validators
{
    public class UpdateServiceRequestValidator : IValidator<UpdateServiceRequest>
    {

        public void Validate(UpdateServiceRequest valueToValidate)
        {
            try
            {
                ValidateRequires(valueToValidate);
            }
            catch (Exception)
            {
                throw new InvalidUpdateServiceRequestInformationException();
            }
        }

        private static void ValidateRequires(UpdateServiceRequest serviceToValidate)
        {
            serviceToValidate.ServiceId.Requires().IsNotNullOrEmpty();
            serviceToValidate.ServiceSellKey.Requires().IsNotNullOrEmpty();
            serviceToValidate.Code.Requires().IsNotNullOrEmpty();
        }
    }
}
