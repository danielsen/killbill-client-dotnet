using KillBillClient.Infrastructure.Api.Interfaces;

namespace KillBillClient.Core.Models
{
    public interface IKillBillObjects
    {
        IKbHttpClient KillBillHttpClient { get; set; }
        int PaginationCurrentOffset { get; set; }

        int PaginationMaxNbRecords { get; set; }

        int PaginationNextOffset { get; set; }

        string PaginationNextPageUri { get; set; }

        int PaginationTotalNbRecords { get; set; }
    }
}