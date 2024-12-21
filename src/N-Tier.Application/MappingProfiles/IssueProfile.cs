using AutoMapper;
using N_Tier.Application.Models.Issue;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class IssueProfile : Profile
{
    public IssueProfile()
    {
        CreateMap<CreateIssueModel, Issue>();

        CreateMap<Issue, IssueResponseModel>();
        CreateMap<UpdateIssueModel, Issue>();
    }
}