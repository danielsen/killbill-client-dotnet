using System;
using KillBillClient.JSON;
using Newtonsoft.Json;

namespace KillBillClient.Model
{
    public class AuditLog
    {
        public string ChangeType { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? ChangeDate { get; set; }

        public string ChangedBy { get; set; }

        public string ReasonCode { get; set; }

        public string Comments { get; set; }

        public string UserToken { get; set; }
    }
}