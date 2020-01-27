namespace NS.Booking.Domain.Booking.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Booking.Exceptions;
    using NS.Booking.Domain.Booking.Models;
    using System.Linq;

    public class BookingValidator : IValidator<Booking>
    {
        public void Validate(Booking valueToValidate)
        {
            if (valueToValidate == null || !valueToValidate.Pax.Any() || !valueToValidate.Journeys.Any())
            {
                throw new InvalidBookingInformationException();
            }
        }
    }
}