using AutoMapper;
using N_Tier.Application.Models.LearnType;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class LearnTypeProfile : Profile
{
    public LearnTypeProfile()
    {
        CreateMap<CreateLearnTypeModel, LearnType>();
        CreateMap<LearnType,LearnTypeResponseModel>();
        CreateMap<UpdateLearnTypeModel, LearnType>();
    }
}