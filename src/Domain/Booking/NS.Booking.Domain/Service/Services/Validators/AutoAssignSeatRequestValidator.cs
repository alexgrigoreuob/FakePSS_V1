namespace NS.Booking.Domain.Service.Services.Validators
{
    using System;
    using System.Linq;
    using Conditions;

    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Service.Exceptions;
    using NS.Booking.Domain.Service.Models.Requests;

    public class AutoAssignSeatRequestValidator : IValidator<AutoAssignSeatRequest>
    {
        public void Validate(AutoAssignSeatRequest valueToValidate)
        {
            try
            {
                ValidateRequires(valueToValidate);
            }
            catch (Exception)
            {
                throw new InvalidAutoAssignSeatRequestInformationException();
            }
        }

        private static void ValidateRequires(AutoAssignSeatRequest serviceToValidate)
        {
            serviceToValidate.SegmentId.Requires().IsNotNullOrEmpty();
            serviceToValidate.Pax.Requires();
        }
    }
}
