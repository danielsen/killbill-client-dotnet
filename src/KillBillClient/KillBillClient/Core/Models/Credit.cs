using System;
using KillBillClient.Infrastructure.Json;
using Newtonsoft.Json;

namespace KillBillClient.Core.Models
{
    public class Credit : KillBillObject
    {
        public Guid AccountId { get; set; }
        public double CreditAmount { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? EffectiveDate { get; set; }

        public Guid? InvoiceId { get; set; }

        public string InvoiceNumber { get; set; }
    }
}