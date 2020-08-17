using System;

namespace KillBillClient.Core.Models
{
    public class InvoiceEmail : KillBillObject
    {
        public Guid AccountId { get; set; }

        public bool IsNotifiedForInvoices { get; set; }
    }
}