using System.Collections.Generic;

namespace KillBillClient.Model
{
    public class PaymentMethodPluginDetail
    {
        public string ExternalPaymentId { get; set; }

        public bool IsDefaultPaymentMethod { get; set; }

        public List<PluginProperty> Properties { get; set; }
    }
}