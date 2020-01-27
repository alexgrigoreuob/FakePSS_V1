namespace NS.Booking.Domain.Booking.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Booking.Exceptions;
    using NS.Booking.Domain.Booking.Models.Requests;

    public class RetrieveBookingRequestValidator : IValidator<RetrieveBookingRequest>
    {
        public void Validate(RetrieveBookingRequest valueToValidate)
        {
            if (string.IsNullOrEmpty(valueToValidate?.RecordLocator) ||
                (string.IsNullOrEmpty(valueToValidate?.PaxSurname) &&
                string.IsNullOrEmpty(valueToValidate?.ContactEmail)))
            {
                throw new InvalidBookingInformationException();
            }
        }
    }
}