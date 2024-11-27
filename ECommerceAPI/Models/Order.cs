namespace ECommerceAPI.Models
{
    public class Order
    {
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public ICollection<OrderItem>  orderItems { get; set; } = new HashSet<OrderItem>();
        public int CustomerId { get; set; }
        public Customer customer { get; set; }

    }
}
