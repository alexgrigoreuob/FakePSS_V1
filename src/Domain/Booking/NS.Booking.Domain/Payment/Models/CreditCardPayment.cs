namespace NS.Booking.Domain.Payment.Models
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Payment.Enums;
    using System.Collections.Generic;

    public class CreditCardPayment : Payment
    {
        private readonly List<IValidator<CreditCardPayment>> _validators;

        public CreditCardPayment()
        {
            PaymentType = PaymentType.CreditCard;
            DccInfo = new DccInfo();
            _validators = IoCContainer.Instance.ResolveAll<IValidator<CreditCardPayment>>();
        }

        /// <summary>
        /// This fields contains a payment method, like "VI" for Visa, "MC" for MasterCard, etc
        /// </summary>
        public string PaymentMethod { get; set; }

        public string CardHolder { get; set; }

        public string CardNumber { get; set; }

        public int ExpirationYear { get; set; }

        public int ExpirationMonth { get; set; }

        public string VerifyCode { get; set; }

        public string ValidationData { get; set; }

        public DccInfo DccInfo { get; set; }

        public new void Validate()
        {
            base.Validate();
            _validators.ForEach(x => x.Validate(this));
        }
    }
}
