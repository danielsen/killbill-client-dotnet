namespace KillBillClient.Model
{
    public class Price : KillBillObject
    {
        public string Currency { get; set; }

        public decimal Value { get; set; }
    }
}