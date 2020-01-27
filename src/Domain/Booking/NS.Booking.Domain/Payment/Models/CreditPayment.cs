namespace NS.Booking.Domain.Payment.Models
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using System.Collections.Generic;

    public class CreditPayment : Payment
    {
        private readonly List<IValidator<CreditPayment>> _validators;
        public CreditPayment()
        {
            _validators = IoCContainer.Instance.ResolveAll<IValidator<CreditPayment>>();
        }
        public decimal Credit { get; set; }
        public string AccountNumber { get; set; }
        public new void Validate()
        {
            base.Validate();
            _validators.ForEach(x => x.Validate(this));
        }
    }
}
