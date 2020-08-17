using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KillBillClient.Data;
using KillBillClient.Model;

namespace KillBillClient.Interfaces.Managers
{
    public interface IKillBillSubscriptionManager
    {
        Task BlockSubscription(Guid subscriptionId, BlockingState blockingState, RequestOptions inputOptions,
            DateTime? requestedDate = null, Dictionary<string, string> pluginProperties = null);

        Task CancelSubscription(Guid subscriptionId, RequestOptions inputOptions, DateTime? requestedDate = null,
            bool? useRequestedDateForBilling = null, EntitlementActionPolicy? entitlementPolicy = null,
            BillingActionPolicy? billingPolicy = null);

        Task<Subscription> CreateSubscription(Subscription subscription, RequestOptions inputOptions,
            DateTime? requestedDate = null, bool? isMigrated = null);

        Task<Bundle> CreateSubscriptionsWithAddOns(IEnumerable<Subscription> subscriptions, RequestOptions inputOptions,
            DateTime? requestedDate = null, int? timeoutSec = null);

        Task<Bundle> CreateSubscriptionWithAddOns(Subscription subscription, RequestOptions inputOptions,
            DateTime? requestedDate = null, int? timeoutSec = null);

        // SUBSCRIPTION
        Task<Subscription> GetSubscription(Guid subscriptionId, RequestOptions inputOptions);

        Task UncancelSubscription(Guid subscriptionId, RequestOptions inputOptions,
            Dictionary<string, string> pluginProperties = null);

        Task<Subscription> UpdateSubscription(Subscription subscription, RequestOptions inputOptions,
            BillingActionPolicy? billingPolicy = null, DateTime? requestedDate = null, bool? isMigrated = null);
    }
}