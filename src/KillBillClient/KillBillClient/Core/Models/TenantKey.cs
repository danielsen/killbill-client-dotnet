using System.Collections.Generic;

namespace KillBillClient.Core.Models
{
    public class TenantKey : KillBillObject
    {
        public string Key { get; set; }

        public List<string> Values { get; set; }
    }
}