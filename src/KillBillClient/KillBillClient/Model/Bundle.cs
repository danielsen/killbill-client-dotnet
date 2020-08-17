﻿using System;
using System.Collections.Generic;

namespace KillBillClient.Model
{
    public class Bundle : KillBillObject
    {
        public Guid AccountId { get; set; }

        public Guid BundleId { get; set; }

        public string ExternalKey { get; set; }

        public List<Subscription> Subscriptions { get; set; }
    }
}