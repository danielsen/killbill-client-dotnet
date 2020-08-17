using System;

namespace KillBillClient.Core.Models
{
    public class AccountEmail : KillBillObject
    {
        public Guid AccountId { get; set; }

        public string Email { get; set; }
    }
}