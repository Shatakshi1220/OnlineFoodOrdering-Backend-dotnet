namespace OnlineFoodService_WebApi.Model
{
    public class Cart
    {
        public int cartId { get; set; }
        public string mImage { get; set; }
        public string menuName { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }

    }
}
