using KillBillClient.Interfaces;

namespace KillBillClient.Model
{
    public interface IKillBillObjects
    {
        int PaginationCurrentOffset { get; set; }

        int PaginationNextOffset { get; set; }

        int PaginationTotalNbRecords { get; set; }

        int PaginationMaxNbRecords { get; set; }

        string PaginationNextPageUri { get; set; }

        IKbHttpClient KillBillHttpClient { get; set; }
    }
}