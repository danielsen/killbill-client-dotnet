using System.Collections.Generic;

namespace KillBillClient.Core.Models
{
    public class BillingException
    {
        public string CauseClassName { get; set; }

        public string CauseMessage { get; set; }
        public string ClassName { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }

        public List<StackTraceElement> StackTrace { get; set; }
    }
}