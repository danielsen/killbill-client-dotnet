﻿using System.Collections.Generic;

namespace KillBillClient.Model
{
    public class TieredBlock
    {
        public string Max { get; set; }

        public List<Price> Prices { get; set; }

        public string Size { get; set; }
        public string Unit { get; set; }
    }
}