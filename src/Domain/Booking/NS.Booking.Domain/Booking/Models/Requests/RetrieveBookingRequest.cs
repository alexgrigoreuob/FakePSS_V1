namespace NS.Booking.Domain.Booking.Models.Requests
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using System.Collections.Generic;

    public class RetrieveBookingRequest
    {
        private readonly List<IValidator<RetrieveBookingRequest>> _validators;

        public RetrieveBookingRequest()
        {
            _validators = IoCContainer.Instance.ResolveAll<IValidator<RetrieveBookingRequest>>();
        }

        public string RecordLocator { get; set; }

        public string ContactEmail { get; set; }

        public string PaxSurname { get; set; }

        public void Validate()
        {
            this._validators.ForEach(x => x.Validate(this));
        }
    }
}