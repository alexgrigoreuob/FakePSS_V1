using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Booking.Domain.Fee.Models.Requests
{
    public class RemoveFeeRequest
    {
        public string FeeCode { get; set; }
        public string PaxId { get; set; }

    }
}
