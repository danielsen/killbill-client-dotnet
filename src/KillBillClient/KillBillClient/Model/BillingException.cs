using System.Collections.Generic;

namespace KillBillClient.Model
{
    public class BillingException
    {
        public string ClassName { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }

        public string CauseClassName { get; set; }

        public string CauseMessage { get; set; }

        public List<StackTraceElement> StackTrace { get; set; }
    }
}
