namespace NS.Booking.Domain.Payment.Models
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Payment.Enums;
    using System.Collections.Generic;

    public class VoucherPayment : Payment
    {
        private readonly List<IValidator<VoucherPayment>> _validators;

        public VoucherPayment()
        {
            PaymentType = PaymentType.Voucher;
            _validators = IoCContainer.Instance.ResolveAll<IValidator<VoucherPayment>>();
        }

        public string VoucherId { get; set; }
        public decimal AvailableAmount { get; set; }
        public new void Validate()
        {
            base.Validate();
            _validators.ForEach(x => x.Validate(this));
        }
    }
}
