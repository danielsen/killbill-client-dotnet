using System;
using System.Collections.Generic;

namespace KillBillClient.Model
{
    public class SubscriptionUsageRecord : KillBillObject
    {
        public Guid SubscriptionId { get; set; }

        public List<UnitUsageRecord> UnitUsageRecords { get; set; }
    }
}