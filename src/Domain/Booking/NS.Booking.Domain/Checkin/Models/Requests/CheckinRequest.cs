namespace NS.Booking.Domain.Checkin.Models.Requests
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using System.Collections.Generic;

    public class CheckinRequest
    {
        private readonly List<IValidator<CheckinRequest>> _validators;

        public CheckinRequest()
        {
            this._validators = IoCContainer.Instance.ResolveAll<IValidator<CheckinRequest>>();

            this.Pax = new List<string>();
        }

        public string SegmentId { get; set; }

        public List<string> Pax { get; set; }

        public void Validate()
        {
            _validators.ForEach(x => x.Validate(this));
        }
    }
}
