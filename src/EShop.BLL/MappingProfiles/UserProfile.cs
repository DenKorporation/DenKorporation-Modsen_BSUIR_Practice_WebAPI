using AutoMapper;
using EShop.BLL.DTO.User;
using EShop.DAL.Entities;

namespace EShop.BLL.MappingProfiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<User, ReadUserDto>().ForMember(u => u.Name, opt => opt.MapFrom(src => src.UserName));
        CreateMap<User, UserDetailsDto>().ForMember(u => u.Name, opt => opt.MapFrom(src => src.UserName));
        CreateMap<RegisterUserDto, User>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(src => src.Name))
            .ForMember(u => u.PasswordHash, opt => opt.Ignore());
    }
}