using AutoMapper;
using N_Tier.Application.Models.RepetitionPlan;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class RepetitionPlanProfile : Profile
{
    public RepetitionPlanProfile()
    {
        CreateMap<CreateRepetitionPlanModel, RepetitionPlan>();
        CreateMap<RepetitionPlan,RepetitionPlanResponseModel>();
        CreateMap<UpdateRepetitionPlanModel, RepetitionPlan>();
    }
}