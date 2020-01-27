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
    public class AgentValidator : IValidator<Agent>
    {
        public void Validate(Agent valueToValidate)
        {
            if (valueToValidate.Type != Enums.AccountType.Agent || valueToValidate.Organization == null || string.IsNullOrEmpty(valueToValidate.Organization.ReferenceId) || string.IsNullOrEmpty(valueToValidate.Username))
            {
                throw new InvalidAgentInformationException();
            }
        }
    }
}
