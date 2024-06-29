using AutoMapper;
using EShop.BLL.DTO.Category;
using EShop.DAL.Entities;

namespace EShop.BLL.MappingProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, ReadCategoryDto>();
        CreateMap<Category, CategoryDetailsDto>();
        CreateMap<CreateCategoryDto, Category>();
    }
}