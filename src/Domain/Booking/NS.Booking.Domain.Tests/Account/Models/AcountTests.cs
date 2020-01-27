using Newshore.Core.NativeObjects.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Booking.Domain.Tests.Account.Models
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void IdIsCorrectlyGeneratedWhenUsernameIsSet()
        {
            var account = new Domain.Account.Models.Account { Username = "Username", ReferenceId = "ReferenceId", Credit = new Domain.Account.Models.CreditAccount { CreditAvailable = 0, CurrencyCode = "UDS" }, Type = Domain.Account.Enums.AccountType.Agent, Status = Domain.Account.Enums.AccountStatus.Active };
            var expectedAccountId = $"{account.Username}~{account.ReferenceId.EncodeHexadecimal()}";
            Assert.AreEqual(account.Id, expectedAccountId.EncodeHexadecimal());
        }

        [Test]
        public void IdIsEmptyWhenThereIsNoUsernameSet()
        {
            var account = new Domain.Account.Models.Account { ReferenceId = "ReferenceId" };
            Assert.AreEqual(account.Id, string.Empty);
        }
    }
}
