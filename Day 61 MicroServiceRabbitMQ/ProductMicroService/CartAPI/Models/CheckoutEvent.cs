namespace CartAPI.Models
{
    public class CheckoutEvent
    {
        public string UserId { get; set; }
        public List<string> ProductIds { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
