using System;
using System.Threading.Tasks;
using KillBillClient.Data;
using KillBillClient.Model;

namespace KillBillClient.Interfaces.Managers
{
    public interface IKillBillNotificationManager
    {
        // INVOICE EMAIL
        Task<InvoiceEmail> GetEmailNotificationsForAccount(Guid accountId, RequestOptions inputOptions);

        Task UpdateEmailNotificationsForAccount(InvoiceEmail invoiceEmail, RequestOptions inputOptions);
    }
}