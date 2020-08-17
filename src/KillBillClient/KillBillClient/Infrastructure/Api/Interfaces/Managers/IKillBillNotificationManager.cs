using System;
using System.Threading.Tasks;
using KillBillClient.Core.Models;

namespace KillBillClient.Infrastructure.Api.Interfaces.Managers
{
    public interface IKillBillNotificationManager
    {
        // INVOICE EMAIL
        Task<InvoiceEmail> GetEmailNotificationsForAccount(Guid accountId, RequestOptions inputOptions);

        Task UpdateEmailNotificationsForAccount(InvoiceEmail invoiceEmail, RequestOptions inputOptions);
    }
}