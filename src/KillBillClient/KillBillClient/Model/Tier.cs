using System.Collections.Generic;

namespace KillBillClient.Model
{
    public class Tier
    {
        public List<TieredBlock> Blocks { get; set; }

        public List<Limit> Limits { get; set; }

        public List<Price> FixedPrice { get; set; }

        public List<Price> RecurringPrice { get; set; }
    }
}