namespace OnlineFoodService_WebApi.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string NameOnCard { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }
        public int CVV { get; set; }
    }
}
