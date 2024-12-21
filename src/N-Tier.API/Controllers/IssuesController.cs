using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Issue;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class IssuesController : ApiController
{
    private readonly IIssueService _issueService;

    public IssuesController (IIssueService issueService)
    {
        _issueService = issueService;
    }

    [HttpGet]
    [Route ("GetIssue")]
    public async Task<IActionResult> GetIssueByIdAsync(int issueId)
    {
        return Ok(await _issueService.GetIssueAsync(issueId));
    }

    [HttpGet]
    [Route("AllIssues")]
    
    public async Task<IActionResult> GetIssuesAsync()
    {
        return Ok(ApiResult<IEnumerable<IssueResponseModel>>.Success(await _issueService.GetAllIssuesAsync()));
    }

    [HttpPost]
    [Route("AddIssue")]
    public async Task<IActionResult> CreateIssue(CreateIssueModel model)
    {
        return Ok(await _issueService.CreateIssueAsync(model));
    }

    [HttpPut]
    [Route("UpdateIssue")]
    public async Task<IActionResult> UpdateIssue(int id,UpdateIssueModel model)
    {
        return Ok(await _issueService.UpdateIssueAsync(id, model));
    }

    [HttpDelete]
    [Route("DeleteIssue")]
    public async Task<IActionResult> DeleteIssue(int issueId)
    {
        return Ok(await _issueService.DeleteIssueAsync(issueId));
    }
}