namespace ECommerceAPI.DTOModels
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemDTO> orderItems { get; set; }
    }
}
