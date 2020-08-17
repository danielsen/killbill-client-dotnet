using System;
using KillBillClient.Infrastructure.Json;
using Newtonsoft.Json;

namespace KillBillClient.Core.Models
{
    public class EventSubscription : EventBaseSubscription
    {
        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? EffectiveDate { get; set; }

        public Guid EventId { get; set; }
    }
}