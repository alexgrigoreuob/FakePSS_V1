namespace NS.Booking.Domain.Booking.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Booking.Exceptions;
    using NS.Booking.Domain.Booking.Models.Requests;
    using System.Linq;

    public class CreateBookingRequestValidator : IValidator<CreateBookingRequest>
    {
        public void Validate(CreateBookingRequest valueToValidate)
        {
            if (valueToValidate?.Booking == null || !valueToValidate.Booking.Pax.Any())
            {
                throw new InvalidBookingInformationException();
            }
        }
    }
}