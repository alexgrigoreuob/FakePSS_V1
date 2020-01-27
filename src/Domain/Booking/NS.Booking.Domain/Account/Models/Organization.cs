using Newshore.Core.DDD.Concepts;
using Newshore.Core.NativeObjects.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Booking.Domain.Account.Models
{
    public class Organization : Aggregate
    {
        public override string Id
        {
            get
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    return string.Empty;
                }

                var refId = string.IsNullOrEmpty(this.ReferenceId) ? string.Empty : this.ReferenceId.EncodeHexadecimal();

                var value = $"{this.Name}~{refId}";
                return value.EncodeHexadecimal();
            }
        }
        public string ReferenceId { get; set; }
        public string Name { get; set; }
    }
}
