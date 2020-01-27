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
    public class Member : Account
    {
        private readonly List<IValidator<Member>> validators;

        public Member()
        {
            this.validators = IoCContainer.Instance.ResolveAll<IValidator<Member>>();
            this.Type = AccountType.Member;
        }

        public void Validate()
        {
            this.validators.ForEach(x => x.Validate(this));
        }
    }
}
