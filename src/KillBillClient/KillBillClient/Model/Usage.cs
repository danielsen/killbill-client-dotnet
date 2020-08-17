using System.Collections.Generic;

namespace KillBillClient.Model
{
    public class Usage
    {
        public string BillingPeriod { get; set; }

        public List<Tier> Tiers { get; set; }
    }
}