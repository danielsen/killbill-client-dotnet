using System;
using KillBillClient.JSON;
using Newtonsoft.Json;

namespace KillBillClient.Model
{
    public class EventSubscription : EventBaseSubscription
    {
        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? EffectiveDate { get; set; }

        public Guid EventId { get; set; }
    }
}