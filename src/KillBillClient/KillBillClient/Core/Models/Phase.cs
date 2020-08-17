using System.Collections.Generic;

namespace KillBillClient.Core.Models
{
    public class Phase : KillBillObject
    {
        public Duration Duration { get; set; }

        public List<Price> FixedPrices { get; set; }

        public List<Price> Prices { get; set; }
        public string Type { get; set; }

        public List<Usage> Usages { get; set; }
    }
}