using System;
using KillBillClient.Infrastructure.Json;
using Newtonsoft.Json;

namespace KillBillClient.Core.Models
{
    public class EventBaseSubscription
    {
        public string BillingPeriod { get; set; }

        public string EventType { get; set; }

        public string Phase { get; set; }

        public string PriceList { get; set; }

        public string Product { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? RequestedDate { get; set; }
    }
}