using Newshore.Core.IoC;
using NS.Booking.Common.Domain.Common.Validators;
using NS.Booking.Domain.Account.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Booking.Domain.Account.Models
{
    public class Agent : Account
    {
        private readonly List<IValidator<Agent>> validators;

        public Agent()
        {
            this.validators = IoCContainer.Instance.ResolveAll<IValidator<Agent>>();
            this.Type = AccountType.Agent;
        }

        public Organization Organization { get; set; }

        public void Validate()
        {
            this.validators.ForEach(x => x.Validate(this));
        }
    }
}
