using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Booking.Pricing.Domain.Fee.Models.Requests
{
    public class RetrieveFeeRequest
    {
        public string FeeCode { get; set; }
        public string CurrencyCode { get; set; }
    }
}
