namespace RecieverService.Models
{
    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string CorrelationId { get; set; }
    }
}
