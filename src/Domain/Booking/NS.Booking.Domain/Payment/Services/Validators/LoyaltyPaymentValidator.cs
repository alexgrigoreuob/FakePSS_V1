namespace NS.Booking.Domain.Payment.Services.Validators
{
    using Conditions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using System;

    public class LoyaltyPaymentValidator : IValidator<LoyaltyPayment>
    {
        public void Validate(LoyaltyPayment valueToValidate)
        {
            try
            {
                valueToValidate.Requires().IsNotNull();
                valueToValidate.Points.Requires().Evaluate(a => a > 0);
            }
            catch (Exception e)
            {
                throw new InvalidLoyaltyPaymentException(e.Message);
            }
        }
    }
}