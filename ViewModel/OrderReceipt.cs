using System.ComponentModel.DataAnnotations;

namespace OnlineFoodService_WebApi.ViewModel
{
    public class OrderReceipt
    {
        [Key]
        public int cartId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? MenuName { get; set; }
      
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}  
