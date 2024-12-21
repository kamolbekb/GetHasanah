using AutoMapper;
using N_Tier.Application.Models.Surah;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class SurahProfile : Profile
{
    public SurahProfile()
    {
        CreateMap<CreateSurahModel, Surah>();
        CreateMap<Surah,SurahResponseModel>();
        CreateMap<UpdateSurahModel, Surah>();
    }
}