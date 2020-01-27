namespace NS.Booking.Domain.BoardingPass.Validators
{
    using Conditions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.BoardingPass.Exceptions;
    using NS.Booking.Domain.BoardingPass.Models.Requests;

    public class BoardingPassRequestValidator : IValidator<BoardingPassRequest>
    {
        public void Validate(BoardingPassRequest valueToValidate)
        {
            try
            {
                valueToValidate.Requires().IsNotNull();
                valueToValidate.SegmentId.Requires().IsNotNullOrEmpty();
                valueToValidate.PaxId.Requires().IsNotNullOrEmpty();
            }
            catch
            {
                throw new InvalidBoardingPassRequestInformationException();
            }
        }
    }
}
