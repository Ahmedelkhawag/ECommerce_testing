using AutoMapper;
using ECommerceAPI.DTOModels;
using ECommerceAPI.Models;

namespace ECommerceAPI.Mapping
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
