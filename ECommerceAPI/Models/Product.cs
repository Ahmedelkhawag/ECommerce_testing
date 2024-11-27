using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

       // public string? Category { get; set; }

     //   public string? Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public ICollection<OrderItem> orederItems { get; set; } = new HashSet<OrderItem>();
    }
}
