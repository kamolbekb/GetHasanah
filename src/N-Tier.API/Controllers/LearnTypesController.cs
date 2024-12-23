using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.LearnType;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class LearnTypesController : ApiController
{
    private readonly ILearnTypeService _learnTypeService;

    public LearnTypesController (ILearnTypeService learnTypeService)
    {
        _learnTypeService = learnTypeService;
    }

    [HttpGet]
    [Route ("GetLearnType")]
    public async Task<IActionResult> GetLearnTypeByIdAsync(int learnTypeId)
    {
        return Ok(await _learnTypeService.GetLearnTypeAsync(learnTypeId));
    }

    [HttpGet]
    [Route("AllLearnTypes")]
    
    public async Task<IActionResult> GetLearnTypesAsync()
    {
        return Ok(ApiResult<IEnumerable<LearnTypeResponseModel>>.Success(await _learnTypeService.GetAllLearnTypesAsync()));
    }
}