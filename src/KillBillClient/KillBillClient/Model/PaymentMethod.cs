using System;

namespace KillBillClient.Model
{
    public class PaymentMethod : KillBillObject
    {
        public Guid? PaymentMethodId { get; set; }

        public string ExternalKey { get; set; }

        public Guid AccountId { get; set; }

        public bool IsDefault { get; set; }

        public string PluginName { get; set; }

        public PaymentMethodPluginDetail PluginInfo { get; set; }
    }
}