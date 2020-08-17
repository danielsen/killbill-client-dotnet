using KillBillClient.Infrastructure.Api.Interfaces.Managers;

namespace KillBillClient.Infrastructure.Api.Interfaces
{
    public interface IKillBillClient : IKillBillTenantManager,
        IKillBillAccountManager,
        IKillBillCatalogManager,
        IKillBillSubscriptionManager,
        IKillBillBundleManager,
        IKillBillInvoiceManager,
        IKillBillPaymentManager,
        IKillBillNotificationManager
    {
        // REQUEST OPTIONS
        RequestOptions BaseOptions(string createdBy = null, string requestId = null, string reason = null,
            string comment = null);
    }
}