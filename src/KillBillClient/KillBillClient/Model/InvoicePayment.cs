using System;

namespace KillBillClient.Model
{
    public class InvoicePayment : Payment
    {
        public Guid TargetInvoiceId { get; set; }
    }
}