using AutoMapper;
using N_Tier.Application.Models.Diary;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class DiaryProfile : Profile
{
    public DiaryProfile()
    {
        CreateMap<CreateDiaryModel, Diary>();
        CreateMap<UpdateDiaryModel, Diary>();

        CreateMap<Diary, DiaryResponseModel>();
    }
}