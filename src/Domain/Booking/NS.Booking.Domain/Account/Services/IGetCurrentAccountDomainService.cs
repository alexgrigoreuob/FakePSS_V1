using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Booking.Domain.Account.Models;

namespace NS.Booking.Domain.Account.Services
{
    public interface IGetCurrentAccountDomainService
    {
        Models.Account Get();
    }
}
