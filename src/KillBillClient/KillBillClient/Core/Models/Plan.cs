using System.Collections.Generic;

namespace KillBillClient.Core.Models
{
    public class Plan : KillBillObject
    {
        public BillingPeriod BillingPeriod { get; set; }
        public string Name { get; set; }

        public List<Phase> Phases { get; set; }
    }
}