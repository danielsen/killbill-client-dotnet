using System;
using System.Collections.Generic;
using KillBillClient.JSON;
using Newtonsoft.Json;

namespace KillBillClient.Model
{
    public class Subscription : KillBillObject
    {
        public Guid AccountId { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? BillingEndDate { get; set; }

        public string BillingPeriod { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? BillingStartDate { get; set; }

        public Guid BundleId { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? CancelledDate { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? ChargedThroughDate { get; set; }

        public List<DeletedEventSubscription> DeletedEvents { get; set; }

        public List<EventSubscription> Events { get; set; }

        public string ExternalKey { get; set; }

        public List<NewEventSubscription> NewEvents { get; set; }

        public string PlanName { get; set; }

        public string PriceList { get; set; }

        public string ProductCategory { get; set; }

        public string ProductName { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? StartDate { get; set; }

        public EntitlementState State { get; set; }

        public Guid SubscriptionId { get; set; }
    }
}