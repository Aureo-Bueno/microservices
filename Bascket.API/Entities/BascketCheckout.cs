namespace Bascket.API.Entities
{
    public class BascketCheckout
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public Payment Payments { get; set; }
    }
}
