namespace NS.Booking.Domain.Payment.Services.Validators
{
    using Conditions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using System;

    public class VoucherPaymentValidator : IValidator<VoucherPayment>
    {
        public void Validate(VoucherPayment valueToValidate)
        {
            try
            {
                valueToValidate.Requires().IsNotNull();
                valueToValidate.VoucherId.Requires().IsNotNullOrEmpty();
            }
            catch (Exception e)
            {
                throw new InvalidVoucherPaymentException(e.Message);
            }
        }
    }
}