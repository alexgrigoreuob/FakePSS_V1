namespace NS.Booking.Domain.Fee.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Fee.Exceptions;
    using NS.Booking.Domain.Fee.Models.Requests;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AddFeeRequestValidator : IValidator<AddFeeRequest>
    {
        public void Validate(AddFeeRequest valueToValidate)
        {
            if (string.IsNullOrEmpty(valueToValidate.Code) || string.IsNullOrEmpty(valueToValidate.PaxId) || string.IsNullOrEmpty(valueToValidate.FeeSellKey))
            {
                throw new InvalidAddFeeRequestException();
            }
        }
    }
}
