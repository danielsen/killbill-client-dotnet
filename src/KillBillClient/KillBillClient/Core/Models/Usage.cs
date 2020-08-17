using System.Collections.Generic;

namespace KillBillClient.Core.Models
{
    public class Usage
    {
        public string BillingPeriod { get; set; }

        public List<Tier> Tiers { get; set; }
    }
}