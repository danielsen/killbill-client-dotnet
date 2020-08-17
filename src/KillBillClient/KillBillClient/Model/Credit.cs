﻿using System;
using KillBillClient.JSON;
using Newtonsoft.Json;

namespace KillBillClient.Model
{
    public class Credit : KillBillObject
    {
        public double CreditAmount { get; set; }

        public Guid? InvoiceId { get; set; }

        public string InvoiceNumber { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? EffectiveDate { get; set; }

        public Guid AccountId { get; set; }
    }
}