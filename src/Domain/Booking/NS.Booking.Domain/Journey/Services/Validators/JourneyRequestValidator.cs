namespace NS.Booking.Domain.Journey.Services.Validators
{
    using Newshore.Core.NativeObjects.Extensions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Journey.Exceptions;
    using NS.Booking.Domain.Journey.Models.Requests;

    public class JourneyRequestValidator : IValidator<JourneyRequest>
    {
        public void Validate(JourneyRequest valueToValidate)
        {
            if (valueToValidate?.JourneyId == null || valueToValidate?.FareId == null ||
                !valueToValidate.JourneyId.IsHexadecimal() || !valueToValidate.FareId.IsHexadecimal())
            {
                throw new InvalidJourneyInformationException();
            }
        }
    }
}
