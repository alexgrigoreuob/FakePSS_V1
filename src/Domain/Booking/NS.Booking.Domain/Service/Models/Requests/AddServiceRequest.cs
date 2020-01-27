namespace NS.Booking.Domain.Service.Models.Requests
{
    using System.Collections.Generic;
    using System.Linq;

    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Charge.Enums;
    using NS.Booking.Common.Domain.Charge.Models;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Common.Domain.Service.Enums;
    public class AddServiceRequest : AddServiceRequestBase
    {
        private readonly List<IValidator<AddServiceRequest>> _validators;

        public AddServiceRequest()
        {
            _validators = IoCContainer.Instance.ResolveAll<IValidator<AddServiceRequest>>();
            this.Charges = new List<Charge>(); 
        }

        public string ServiceSellKey { get; set; }

        public ServiceType Type { get; set; }

        /// <summary>
        /// this charges list is only to can override the price of the service when we will add to pss.
        // </summary>
        public List<Charge> Charges { get; set; }

        public decimal TotalAmount
        {
            get
            {
                var price = this.Charges.Where(x => x.Type != ChargeType.Discount).Sum(x => x.Amount);
                var discount = this.Charges.Where(x => x.Type == ChargeType.Discount).Sum(x => x.Amount);
                return price - discount;
            }
        }

        public void Validate()
        {
            _validators.ForEach(x => x.Validate(this));
        }

    }
}
