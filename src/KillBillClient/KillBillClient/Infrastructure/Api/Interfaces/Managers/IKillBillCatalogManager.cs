using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KillBillClient.Core.Models;

namespace KillBillClient.Infrastructure.Api.Interfaces.Managers
{
    public interface IKillBillCatalogManager
    {
        Task<List<PlanDetail>> GetAvailableAddons(string baseProductName, RequestOptions inputOptions);

        // PLAN
        Task<List<PlanDetail>> GetBasePlans(RequestOptions inputOptions);

        // CATALOG
        Task<List<Catalog>> GetCatalogJson(RequestOptions inputOptions, DateTime? requestedDate = null);

        Task<Plan> GetPlanFromSubscription(Guid subscriptionId, RequestOptions inputOptions,
            DateTime? requestedDate = null);

        // PRICE LIST
        Task<PriceList> GetPriceListFromSubscription(Guid subscriptionId, RequestOptions inputOptions,
            DateTime? requestedDate = null);

        // PRODUCT
        Task<Product> GetProductFromSubscription(Guid subscriptionId, RequestOptions inputOptions,
            DateTime? requestedDate = null);

        Task UploadCatalogXml(string catalogXml, RequestOptions inputOptions);
    }
}