using System.Collections.Generic;

namespace KillBillClient.Core.Models
{
    public class KillBillObject : object
    {
        public KillBillObject()
        {
        }

        public KillBillObject(List<AuditLog> auditLogs)
        {
            AuditLogs = auditLogs;
        }

        public List<AuditLog> AuditLogs { get; set; }
    }
}