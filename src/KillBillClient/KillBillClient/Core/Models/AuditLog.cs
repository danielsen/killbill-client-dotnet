using System;
using KillBillClient.Infrastructure.Json;
using Newtonsoft.Json;

namespace KillBillClient.Core.Models
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