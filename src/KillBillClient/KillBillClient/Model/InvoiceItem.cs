using System;
using KillBillClient.JSON;
using Newtonsoft.Json;

namespace KillBillClient.Model
{
    public class InvoiceItem : KillBillObject
    {
        public Guid AccountId { get; set; }

        public double Amount { get; set; }

        public Guid? BundleId { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? EndDate { get; set; }

        public Guid? InvoiceId { get; set; }
        public Guid? InvoiceItemId { get; set; }

        public string ItemType { get; set; }

        public Guid? LinkedInvoiceItemId { get; set; }

        public string PhaseName { get; set; }

        public string PlanName { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? StartDate { get; set; }

        public Guid? SubscriptionId { get; set; }

        public string UsageName { get; set; }
    }
}