namespace NS.Booking.Domain.Payment.Models
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using System.Collections.Generic;

    public class LoyaltyPayment : Payment
    {
        private readonly List<IValidator<LoyaltyPayment>> _validators;

        public LoyaltyPayment()
        {
            _validators = IoCContainer.Instance.ResolveAll<IValidator<LoyaltyPayment>>();
        }

        public decimal Points { get; set; }

        public new void Validate()
        {
            base.Validate();
            _validators.ForEach(x => x.Validate(this));
        }
    }
}
