using System;

namespace KillBillClient.Core.Models
{
    public class PaymentMethod : KillBillObject
    {
        public Guid AccountId { get; set; }

        public string ExternalKey { get; set; }

        public bool IsDefault { get; set; }
        public Guid? PaymentMethodId { get; set; }

        public PaymentMethodPluginDetail PluginInfo { get; set; }

        public string PluginName { get; set; }
    }
}