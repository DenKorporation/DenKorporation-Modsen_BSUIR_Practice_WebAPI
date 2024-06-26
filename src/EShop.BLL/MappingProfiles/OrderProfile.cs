using AutoMapper;
using EShop.BLL.DTO.Order;
using EShop.DAL.Entities;

namespace EShop.BLL.MappingProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, ReadOrderDto>();
        CreateMap<Order, OrderDetailsDto>();
        CreateMap<CreateOrderDto, Order>();
    }
}