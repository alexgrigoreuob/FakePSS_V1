namespace NS.Booking.Domain.Payment.Models
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Payment.Enums;
    using System.Collections.Generic;

    public class PrePaidPayment : Payment
    {
        private readonly List<IValidator<PrePaidPayment>> _validators;

        public PrePaidPayment()
        {
            PaymentType = PaymentType.PrePaid;
            _validators = IoCContainer.Instance.ResolveAll<IValidator<PrePaidPayment>>();
        }

        /// <summary>
        /// This fields contains a payment method, like "WP" for WorldPay, "JI" for Jimu, etc
        /// </summary>
        public string PaymentMethod { get; set; }

        public string Token { get; set; }

        public new void Validate()
        {
            base.Validate();
            _validators.ForEach(x => x.Validate(this));
        }
    }
}
