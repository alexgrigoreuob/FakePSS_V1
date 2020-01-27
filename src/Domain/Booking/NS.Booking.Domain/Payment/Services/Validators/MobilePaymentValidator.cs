namespace NS.Booking.Domain.Payment.Services.Validators
{
    using Conditions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using System;

    public class MobilePaymentValidator : IValidator<MobilePayment>
    {
        public void Validate(MobilePayment valueToValidate)
        {
            try
            {
                valueToValidate.Requires().IsNotNull();
                valueToValidate.Phone.Requires().IsNotNullOrEmpty();
                valueToValidate.Prefix.Requires().IsNotNullOrEmpty();
                valueToValidate.Country.Requires().IsNotNullOrEmpty();
            }
            catch (Exception e)
            {
                throw new InvalidMobilePaymentException(e.Message);
            }
        }
    }
}
