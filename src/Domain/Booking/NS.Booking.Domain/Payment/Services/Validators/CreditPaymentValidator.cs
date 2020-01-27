namespace NS.Booking.Domain.Payment.Services.Validators
{
    using Conditions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using System;

    public class CreditPaymentValidator : IValidator<CreditPayment>
    {
        public void Validate(CreditPayment valueToValidate)
        {
            try
            {
                valueToValidate.Requires().IsNotNull();
                valueToValidate.Credit.Requires().Evaluate(a => a > 0);
                valueToValidate.AccountNumber.Requires().IsNotNullOrEmpty();
            }
            catch (Exception e)
            {
                throw new InvalidCreditPaymentException(e.Message);
            }
        }
    }
}
