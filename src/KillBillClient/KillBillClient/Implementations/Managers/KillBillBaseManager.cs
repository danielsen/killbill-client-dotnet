using System.Collections.Generic;
using System.Text;
using System.Web;
using KillBillClient.Core;
using KillBillClient.Infrastructure;
using KillBillClient.Infrastructure.Configuration;
using KillBillClient.Infrastructure.Data;

namespace KillBillClient.Implementations.Managers
{
    public class KillBillBaseManager
    {
        protected const AuditLevel DefaultAuditLevel = AuditLevel.NONE;

        public KillBillBaseManager(KillBillConfiguration configuration)
        {
            Configuration = configuration;
        }

        public KillBillConfiguration Configuration { get; private set; }

        public void StorePluginPropertiesAsParams(Dictionary<string, string> pluginProperties,
            ref MultiMap<string> queryParams)
        {
            if (pluginProperties == null)
                return;

            foreach (var key in pluginProperties.Keys)
            {
                if (queryParams == null)
                    queryParams = new MultiMap<string>();

                queryParams.Add(Configuration.QUERY_PLUGIN_PROPERTY,
                    $"{Encoding.UTF8.GetBytes(key)}={HttpUtility.UrlEncode(pluginProperties[key])}");
            }
        }
    }
}