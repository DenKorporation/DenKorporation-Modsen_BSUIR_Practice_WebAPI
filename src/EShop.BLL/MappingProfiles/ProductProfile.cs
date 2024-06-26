using AutoMapper;
using EShop.BLL.DTO.Product;
using EShop.DAL.Entities;

namespace EShop.BLL.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ReadProductDto>();
        CreateMap<Product, ProductDetailsDto>();
        CreateMap<CreateProductDto, Product>();
    }
}