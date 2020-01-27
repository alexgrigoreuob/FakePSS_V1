namespace NS.Booking.Domain.Search.Models.Requests
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Search.Enums;
    using System.Collections.Generic;

    public class SearchBookingRequest
    {
        private readonly List<IValidator<SearchBookingRequest>> _validators;

        public SearchBookingRequest()
        {
            this._validators = IoCContainer.Instance.ResolveAll<IValidator<SearchBookingRequest>>();
        }

        public int Page { get; set; }

        public int ItemsPerPage { get; set; }

        public List<KeyValuePair<SearchBookingFilterType, string>> Filters { get; set; }

        public void Validate()
        {
            this._validators.ForEach(x => x.Validate(this));
        }
    }
}
