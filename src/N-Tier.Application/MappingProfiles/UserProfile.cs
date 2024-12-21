using AutoMapper;
using N_Tier.Application.Models.User;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserModel, User>();
        CreateMap<User,UserResponseModel>();
        CreateMap<UpdateUserModel, User>();
    }
}