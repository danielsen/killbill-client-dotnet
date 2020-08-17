using System.Collections.Generic;

namespace KillBillClient.Model
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