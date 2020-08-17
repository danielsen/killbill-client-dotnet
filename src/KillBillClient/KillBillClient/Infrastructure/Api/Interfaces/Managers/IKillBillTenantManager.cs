using System;
using System.Threading.Tasks;
using KillBillClient.Core.Models;

namespace KillBillClient.Infrastructure.Api.Interfaces.Managers
{
    public interface IKillBillTenantManager
    {
        // TENANT
        Task<Tenant> CreateTenant(Tenant tenant, RequestOptions inputOptions, bool useGlobalDefault = true);

        Task<TenantKey> GetCallbackNotificationForTenant(RequestOptions inputOptions);

        Task<Tenant> GetTenant(Guid tenantId, RequestOptions inputOptions);

        Task<Tenant> GetTenant(string apiKey, RequestOptions inputOptions);

        // TENANT KEY
        Task<TenantKey> RegisterCallBackNotificationForTenant(string callback, RequestOptions inputOptions);

        Task UnregisterCallbackNotificationForTenant(Guid tenantId, RequestOptions inputOptions);
    }
}