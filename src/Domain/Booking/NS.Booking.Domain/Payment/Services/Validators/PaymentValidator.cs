namespace NS.Booking.Domain.Payment.Services.Validators
{
    using Conditions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using System;

    public class PaymentValidator : IValidator<Payment>
    {
        public void Validate(Payment valueToValidate)
        {
            try
            {
                ValidateRequires(valueToValidate);
            }
            catch (Exception e)
            {
                throw new InvalidPaymentException(e.Message);
            }
        }

        private static void ValidateRequires(Payment paymentToValidate)
        {
            paymentToValidate.Amount.Requires().Evaluate(a => a > 0);
            paymentToValidate.Currency.Requires().IsNotNullOrEmpty();
            paymentToValidate.PaymentDate.Requires().IsGreaterThan(DateTime.MinValue);
            paymentToValidate.PaymentType.Requires().Evaluate(t => t.GetType().IsEnum);
            paymentToValidate.Status.Requires().Evaluate(s => s.GetType().IsEnum);
        }
    }
}
