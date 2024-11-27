using System.Reflection.PortableExecutable;

namespace ECommerceAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string  FullName { get; set; }

        public string Email { get; set; }

        public ICollection<Order> orders { get; set; } = new HashSet<Order>();
    }
}
