namespace NS.Booking.Domain.Payment.Services.Validators
{
    using Conditions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using System;

    public class PrePaidPaymentValidator : IValidator<PrePaidPayment>
    {
        public void Validate(PrePaidPayment valueToValidate)
        {
            try
            {
                valueToValidate.Requires().IsNotNull();
                valueToValidate.PaymentMethod.Requires().IsNotNullOrEmpty();
            }
            catch (Exception e)
            {
                throw new InvalidPrePaidPaymentException(e.Message);
            }
        }
    }
}
