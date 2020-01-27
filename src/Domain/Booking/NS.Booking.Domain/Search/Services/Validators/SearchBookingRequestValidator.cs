namespace NS.Booking.Domain.Search.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Search.Exceptions;
    using NS.Booking.Domain.Search.Models.Requests;

    public class SearchBookingRequestValidator : IValidator<SearchBookingRequest>
    {
        public void Validate(SearchBookingRequest valueToValidate)
        {
            if (valueToValidate == null || valueToValidate.ItemsPerPage == 0 || valueToValidate.Page == 0)
            {
                throw new InvalidSearchInformationException();
            }
        }
    }
}
