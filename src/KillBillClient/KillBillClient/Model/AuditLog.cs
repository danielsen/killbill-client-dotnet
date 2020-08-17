using System;
using KillBillClient.JSON;
using Newtonsoft.Json;

namespace KillBillClient.Model
{
    public class AuditLog
    {
        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime? ChangeDate { get; set; }

        public string ChangedBy { get; set; }
        public string ChangeType { get; set; }

        public string Comments { get; set; }

        public string ReasonCode { get; set; }

        public string UserToken { get; set; }
    }
}