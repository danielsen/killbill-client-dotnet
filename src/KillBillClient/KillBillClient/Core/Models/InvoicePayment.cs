using System;

namespace KillBillClient.Core.Models
{
    public class InvoicePayment : Payment
    {
        public Guid TargetInvoiceId { get; set; }
    }
}