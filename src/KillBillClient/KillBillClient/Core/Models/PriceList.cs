using System.Collections.Generic;

namespace KillBillClient.Core.Models
{
    public class PriceList
    {
        public string Name { get; set; }

        public List<string> Plans { get; set; }
    }
}