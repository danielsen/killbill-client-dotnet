using System;
using System.Collections.Generic;

namespace KillBillClient.Model
{
    public class Catalog : KillBillObject
    {
        public List<string> Currencies { get; set; }

        public DateTime EffectiveDate { get; set; }
        public string Name { get; set; }

        public List<PriceList> PriceLists { get; set; }

        public List<Product> Products { get; set; }
    }
}