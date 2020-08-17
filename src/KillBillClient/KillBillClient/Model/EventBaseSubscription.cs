using System;
using KillBillClient.JSON;
using Newtonsoft.Json;

namespace KillBillClient.Model
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