namespace KillBillClient.Core.Models
{
    public class Price : KillBillObject
    {
        public string Currency { get; set; }

        public decimal Value { get; set; }
    }
}