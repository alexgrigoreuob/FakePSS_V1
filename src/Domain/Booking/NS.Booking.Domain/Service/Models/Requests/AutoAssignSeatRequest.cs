

namespace NS.Booking.Domain.Service.Models.Requests
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using System.Collections.Generic;
    public class AutoAssignSeatRequest
    {
        private readonly List<IValidator<AutoAssignSeatRequest>> _validators;

        public AutoAssignSeatRequest()
        {
            this._validators = IoCContainer.Instance.ResolveAll<IValidator<AutoAssignSeatRequest>>();

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

