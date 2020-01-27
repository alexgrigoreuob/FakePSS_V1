using Newshore.Core.IoC;
using NS.Booking.Common.Domain.Charge.Enums;
using NS.Booking.Common.Domain.Charge.Models;
using NS.Booking.Common.Domain.Common.Validators;
using NS.Booking.Common.Domain.Service.Enums;
using System.Collections.Generic;
using System.Linq;

namespace NS.Booking.Domain.Service.Models.Requests
{
    public class UpdateServiceRequest
    {
        private readonly List<IValidator<UpdateServiceRequest>> _validators;

        public UpdateServiceRequest()
        {
            _validators = IoCContainer.Instance.ResolveAll<IValidator<UpdateServiceRequest>>();
        }
        /// <summary>
        /// Service Id to update
        /// </summary>
        public string ServiceId { get; set; }
        /// <summary>
        /// Key with necessary information of CSS to add service
        /// </summary>
        public string ServiceSellKey { get; set; }
        public string Code { get; set; }
        public ServiceType Type { get; set; }
        public string PaxId { get; set; }
        public string SellKey { get; set; }
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
