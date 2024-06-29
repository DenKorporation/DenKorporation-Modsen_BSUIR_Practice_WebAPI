using AutoMapper;
using EShop.BLL.DTO.OrderItem;
using EShop.DAL.Entities;

namespace EShop.BLL.MappingProfiles;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, ReadOrderItemDto>();
        CreateMap<OrderItem, OrderItemDetailsDto>();
        CreateMap<CreateOrderItemDto, OrderItem>();
    }
}