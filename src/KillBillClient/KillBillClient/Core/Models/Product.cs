using System.Collections.Generic;

namespace KillBillClient.Core.Models
{
    public class Product : KillBillObject
    {
        public List<string> Available { get; set; }

        public List<string> Included { get; set; }

        public string Name { get; set; }

        public List<Plan> Plans { get; set; }
        public string Type { get; set; }
    }
}