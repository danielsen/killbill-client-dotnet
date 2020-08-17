using System;
using System.Collections.Generic;
using KillBillClient.JSON;
using Newtonsoft.Json;

namespace KillBillClient.Model
{
    public class Invoice : KillBillObject
    {
        public Guid AccountId { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
        public double CreditAdj { get; set; }
        public List<Credit> Credits { get; set; }
        public string Currency { get; set; }
        public string ExternalBundleKeys { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime InvoiceDate { get; set; }

        public Guid InvoiceId { get; set; }
        public int InvoiceNumber { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public double RefundAdj { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime TargetDate { get; set; }
    }
}