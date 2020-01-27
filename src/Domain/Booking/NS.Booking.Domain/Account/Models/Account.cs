using Newshore.Core.DDD.Concepts;
using Newshore.Core.NativeObjects.Extensions;
using NS.Booking.Domain.Account.Enums;
using NS.Booking.Domain.Payment.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Booking.Domain.Account.Models
{
    public class Account : Aggregate
    {
        public override string Id
        {
            get
            {
                if (string.IsNullOrEmpty(this.Username))
                {
                    return string.Empty;
                }

                var refId = string.IsNullOrEmpty(this.ReferenceId) ? string.Empty : this.ReferenceId.EncodeHexadecimal();

                var value = $"{this.Username}~{refId}";
                return value.EncodeHexadecimal();

            }
        }
        public string Username { get; set; }
        public string ReferenceId { get; set; }
        public AccountType Type { get; set; }
        public CreditAccount Credit { get; set; }
        public AccountStatus Status { get; set; }
    }
}
