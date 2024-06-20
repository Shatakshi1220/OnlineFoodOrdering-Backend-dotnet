namespace OnlineFoodService_WebApi.Model
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public int RestaurantId { get; set; }
        public string? MenuName { get; set; }
        public decimal Price { get; set; }

        public string? MImage { get; set; }

        public int Quantity { get; set; }
    }
}
