namespace NS.Booking.Domain.Payment.Services.Validators
{
    using Conditions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Payment.Enums;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using System;

    public class CreditCardPaymentValidator : IValidator<CreditCardPayment>
    {
        public void Validate(CreditCardPayment valueToValidate)
        {
            try
            {
                ValidateRequires(valueToValidate);
                ValidateExpirationDate(valueToValidate.ExpirationMonth, valueToValidate.ExpirationYear);
                ValidateDccInfo(valueToValidate.DccInfo);
            }
            catch (Exception e)
            {
                throw new InvalidCreditCardPaymentException(e.Message);
            }
        }

        private static void ValidateRequires(CreditCardPayment valueToValidate)
        {
            valueToValidate.Requires().IsNotNull();
            valueToValidate.CardHolder.Requires().IsNotNullOrEmpty();
            valueToValidate.CardNumber.Requires().IsNotNullOrEmpty();
            valueToValidate.PaymentMethod.Requires().IsNotNullOrEmpty();
        }

        private static void ValidateExpirationDate(int expirationMonth, int expirationYear)
        {
            var currentYear = DateTime.Now.Year;
            var twoDigitCurrentYear = currentYear % 100;
            var currentMonth = DateTime.Now.Month;

            expirationMonth.Requires().Evaluate(m => m >= 1 && m <= 12);

            //If year is expressed with only two digits, ex. 19
            if (expirationYear < 100)
            {
                expirationYear.Requires().Evaluate(y => y >= twoDigitCurrentYear);
            }
            else
            {
                expirationYear.Requires().Evaluate(y => y >= currentYear);
            }

            if (expirationYear == twoDigitCurrentYear || expirationYear == currentYear)
            {
                expirationMonth.Requires().Evaluate(m => m >= currentMonth);
            }
        }

        private static void ValidateDccInfo(DccInfo dccInfo)
        {
            dccInfo.DccStatus.Requires().Evaluate(d => d.GetType().IsEnum);

            if (dccInfo.DccStatus == DccStatus.OfferAccepted)
            {
                dccInfo.ForeignAmount.Requires().Evaluate(a => a > 0);
                dccInfo.ForeignCurrencyCode.Requires().IsNotNullOrEmpty();
                dccInfo.ForeignExchangeRate.Requires().Evaluate(e => e > 0);
            }
        }
    }
}
