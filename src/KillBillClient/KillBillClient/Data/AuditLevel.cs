﻿namespace KillBillClient.Data
{
    public enum AuditLevel
    {
        // All audits
        FULL,

        // Initial inserts only
        MINIMAL,

        // No audit
        NONE
    }
}