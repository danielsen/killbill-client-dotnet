using System.Collections.Generic;
using System.Threading.Tasks;
using KillBillClient.Data;
using KillBillClient.Infrastructure.Api;
using KillBillClient.Infrastructure.Api.Interfaces;

namespace KillBillClient.Core.Models
{
    public class KillBillObjects<T> : List<T>, IKillBillObjects
    {
        // TODO: revisit this once the java client is updated to use requestOptions
        public async Task<KillBillObjects<T>> GetNext(RequestOptions requestOptions)
        {
            if (KillBillHttpClient == null || PaginationNextPageUri == null)
                return null;

            return await KillBillHttpClient.Get<KillBillObjects<T>>(PaginationNextPageUri, requestOptions);
        }

        public int PaginationCurrentOffset { get; set; }

        public int PaginationNextOffset { get; set; }

        public int PaginationTotalNbRecords { get; set; }

        public int PaginationMaxNbRecords { get; set; }

        public string PaginationNextPageUri { get; set; }

        public IKbHttpClient KillBillHttpClient { get; set; }
    }
}