using System;
using System.Collections.Generic;

namespace KillBillClient.Model
{
    public class Catalog : KillBillObject
    {
        public string Name { get; set; }

        public DateTime EffectiveDate { get; set; }

        public List<string> Currencies { get; set; }

        public List<Product> Products { get; set; }

        public List<PriceList> PriceLists { get; set; }
    }
}
