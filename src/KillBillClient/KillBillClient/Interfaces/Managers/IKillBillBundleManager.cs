using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KillBillClient.Data;
using KillBillClient.Model;

namespace KillBillClient.Interfaces.Managers
{
    public interface IKillBillBundleManager
    {
        Task BlockBundle(Guid bundleId, BlockingState blockingState, RequestOptions inputOptions,
            DateTime? requestedDate = null, Dictionary<string, string> pluginProperties = null);

        // BUNDLE
        Task<Bundle> GetBundle(Guid bundleId, RequestOptions inputOptions);

        Task<Bundle> GetBundle(string externalKey, RequestOptions inputOptions);

        // BUNDLES
        Task<Bundles> GetBundles(RequestOptions inputOptions, long offset = 0L, long limit = 100L,
            AuditLevel auditLevel = AuditLevel.NONE);

        Task PauseBundle(Guid bundleId, RequestOptions inputOptions, DateTime? requestedDate = null,
            Dictionary<string, string> pluginProperties = null);

        Task ResumeBundle(Guid bundleId, RequestOptions inputOptions, DateTime? requestedDate = null,
            Dictionary<string, string> pluginProperties = null);

        Task<Bundles> SearchBundles(string key, RequestOptions inputOptions, long offset = 0L, long limit = 100L,
            AuditLevel auditLevel = AuditLevel.NONE);

        Task<Bundle> TransferBundle(Bundle bundle, RequestOptions inputOptions);
    }
}