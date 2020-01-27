namespace NS.Booking.Domain.Checkin.Validators
{
    using Conditions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Checkin.Exceptions;
    using NS.Booking.Domain.Checkin.Models.Requests;

    public class CheckinRequestValidator : IValidator<CheckinRequest>
    {
        public void Validate(CheckinRequest valueToValidate)
        {
            try
            { 
                valueToValidate.Requires().IsNotNull();
                valueToValidate.SegmentId.Requires().IsNotNullOrEmpty();
                valueToValidate.Pax.ForEach(x => 
                {
                    x.Requires().IsNotNullOrEmpty();
                });
            }
            catch
            {
                throw new InvalidCheckinRequestInformationException();
            }
        }
    }
}
