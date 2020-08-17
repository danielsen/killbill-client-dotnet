using System.Collections.Generic;

namespace KillBillClient.Model
{
    public class Plan : KillBillObject
    {
        public string Name { get; set; }

        public BillingPeriod BillingPeriod { get; set; }

        public List<Phase> Phases { get; set; }
    }
}