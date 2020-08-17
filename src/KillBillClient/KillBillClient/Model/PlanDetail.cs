﻿using System.Collections.Generic;

namespace KillBillClient.Model
{
    public class PlanDetail : KillBillObject
    {
        public string Product { get; set; }

        public string Plan { get; set; }

        public BillingPeriod FinalPhaseBillingPeriod { get; set; }

        public string PriceList { get; set; }

        public List<Price> FinalPhaseRecurringPrice { get; set; }
    }
}