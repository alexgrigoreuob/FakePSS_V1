using NS.Booking.Domain.Account.Models;
using NS.Booking.Domain.Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Booking.Domain.Payment.Services
{
    public interface IAvailableCreditDomainService
    {
        CreditAccount GetAvailableCredit();
    }
}
