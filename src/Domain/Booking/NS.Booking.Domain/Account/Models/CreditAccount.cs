using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Booking.Domain.Account.Models
{
    public class CreditAccount
    {
        public decimal CreditAvailable { get; set; }
        public string CurrencyCode { get; set; }
    }
}
