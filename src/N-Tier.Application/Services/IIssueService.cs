using N_Tier.Application.Models;
using N_Tier.Application.Models.Issue;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services;

public interface IIssueService
{
    Task<CreateIssueResponseModel> CreateIssueAsync(CreateIssueModel createIssueModel);
    Task<Issue> GetIssueAsync(int Id);
    Task<IEnumerable<IssueResponseModel>> GetAllIssuesAsync();
    Task<UpdateIssueResponseModel> UpdateIssueAsync(int id, UpdateIssueModel updateIssueModel);
    Task<BaseResponseModel> DeleteIssueAsync(int id);
}