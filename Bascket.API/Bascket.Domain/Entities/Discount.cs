namespace Bascket.Domain.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
