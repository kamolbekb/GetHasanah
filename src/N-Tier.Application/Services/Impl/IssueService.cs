using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Extensions;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Issue;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class IssueService : IIssueService
{
    private readonly IMapper _mapper;
    private readonly IIssueRepository _issueRepository;

    public IssueService(IMapper mapper, IIssueRepository issueRepository)
    {
        _mapper = mapper;
        _issueRepository = issueRepository;
    }

    public async Task<CreateIssueResponseModel> CreateIssueAsync(CreateIssueModel createIssueModel)
    {
        var issue = _mapper.Map<Issue>(createIssueModel);
        var addedIssue = await _issueRepository.InsertAsync(issue);
        return new CreateIssueResponseModel
        {
            Id = addedIssue.Id,
        };
    }
    
    public async Task<Issue> GetIssueAsync(int issueId)
    {
        var storageIssue = await _issueRepository
            .SelectByIdAsync(issueId);

        return await Task.FromResult(storageIssue);
    }

    public async Task<IEnumerable<IssueResponseModel>> GetAllIssuesAsync()
    {
        var issues = _issueRepository
            .SelectAll();
        return await Task.FromResult(_mapper.Map<IEnumerable<IssueResponseModel>>(issues));
    }

    public Task<PagedResult<IssueResponseModel>> GetAllIssuesAsync(Options options)
    {
        object issues = _issueRepository
            .SelectAll()
            .ToPagedResultAsync(options);
        return Task.FromResult<PagedResult<IssueResponseModel>>(_mapper.Map<PagedResult<IssueResponseModel>>(issues));
    }

    public async Task<UpdateIssueResponseModel> UpdateIssueAsync(int id, UpdateIssueModel updateIssueModel)
    {
        var issue = _issueRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        _mapper.Map(updateIssueModel, issue);
        var updatedIssue = await _issueRepository.UpdateAsync(issue);
        return new UpdateIssueResponseModel
        {
            Id = updatedIssue.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteIssueAsync(int id)
    {
        var issue = _issueRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        await _issueRepository.DeleteAsync(issue);
        await _issueRepository.SaveChangesAsync();
        return new BaseResponseModel();

    }
}