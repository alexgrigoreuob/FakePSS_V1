using NS.Booking.Common.Domain.Common.Validators;
using NS.Booking.Domain.Account.Exceptions;
using NS.Booking.Domain.Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Booking.Domain.Account.Services.Validators
{
    public class MemberValidator : IValidator<Member>
    {
        public void Validate(Member valueToValidate)
        {
            if (valueToValidate.Type != Enums.AccountType.Member || string.IsNullOrEmpty(valueToValidate.ReferenceId) || string.IsNullOrEmpty(valueToValidate.Username))
            {
                throw new InvalidMemberInformationException();
            }
        }
    }
}
