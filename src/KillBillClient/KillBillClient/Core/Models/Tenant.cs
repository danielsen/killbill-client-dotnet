using System;

namespace KillBillClient.Core.Models
{
    public class Tenant : KillBillObject
    {
        public string ApiKey { get; set; }

        public string ApiSecret { get; set; }

        public string ExternalKey { get; set; }
        public Guid TenantId { get; set; }
    }
}