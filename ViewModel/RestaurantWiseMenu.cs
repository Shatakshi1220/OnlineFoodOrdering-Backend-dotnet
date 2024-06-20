using System.ComponentModel.DataAnnotations;

namespace OnlineFoodService_WebApi.ViewModel
{
    public class RestaurantWiseMenu
    {
        [Key]
        public int MenuItemId { get; set; }
        public int RestaurantId { get; set; }

       
        public string? RName { get; set; }

        public string? MenuName { get; set; }

        public decimal Price { get; set; }

    }
}
