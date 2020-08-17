using System;
using System.Collections.Generic;

namespace KillBillClient.Model
{
    public class PaymentTransaction
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public DateTime EffectiveDate { get; set; }

        public string FirstPaymentReferenceId { get; set; }

        public string GatewayErrorCode { get; set; }

        public string GatewayErrorMsg { get; set; }

        public string PaymentExternalKey { get; set; }

        public Guid? PaymentId { get; set; }

        public List<PluginProperty> Properties { get; set; }

        public string SecondPaymentReferenceId { get; set; }

        public string Status { get; set; }

        public string TransactionExternalKey { get; set; }
        public Guid? TransactionId { get; set; }

        public string TransactionType { get; set; }
    }
}