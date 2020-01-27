namespace NS.Booking.Domain.Payment.Models
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using System.Collections.Generic;

    public class MobilePayment : Payment
    {
        private readonly List<IValidator<MobilePayment>> _validators;

        public MobilePayment()
        {
            _validators = IoCContainer.Instance.ResolveAll<IValidator<MobilePayment>>();
        }

        public string Phone { get; set; }

        public string Country { get; set; }

        public string Operator { get; set; }

        public string Prefix { get; set; }
        
        public new void Validate()
        {
            base.Validate();
            _validators.ForEach(x => x.Validate(this));
        }
    }
}
