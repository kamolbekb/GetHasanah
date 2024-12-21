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

    [HttpPost]
    [Route("AddLearnType")]
    public async Task<IActionResult> CreateLearnType(CreateLearnTypeModel model)
    {
        return Ok(await _learnTypeService.CreateLearnTypeAsync(model));
    }

    [HttpPut]
    [Route("UpdateLearnType")]
    public async Task<IActionResult> UpdateLearnType(int id,UpdateLearnTypeModel model)
    {
        return Ok(await _learnTypeService.UpdateLearnTypeAsync(id, model));
    }

    [HttpDelete]
    [Route("DeleteLearnType")]
    public async Task<IActionResult> DeleteLearnType(int learnTypeId)
    {
        return Ok(await _learnTypeService.DeleteLearnTypeAsync(learnTypeId));
    }
}