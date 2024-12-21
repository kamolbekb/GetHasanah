using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.RepetitionPlan;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class RepetitionPlansController : ApiController
{
    private readonly IRepetitionPlanService _repetitionPlanService;

    public RepetitionPlansController (IRepetitionPlanService repetitionPlanService)
    {
        _repetitionPlanService = repetitionPlanService;
    }

    [HttpGet]
    [Route ("GetRepetitionPlan")]
    public async Task<IActionResult> GetRepetitionPlanByIdAsync(int repetitionPlanId)
    {
        return Ok(await _repetitionPlanService.GetRepetitionPlanAsync(repetitionPlanId));
    }

    [HttpGet]
    [Route("AllRepetitionPlans")]
    
    public async Task<IActionResult> GetRepetitionPlansAsync()
    {
        return Ok(ApiResult<IEnumerable<RepetitionPlanResponseModel>>.Success(await _repetitionPlanService.GetAllRepetitionPlansAsync()));
    }

    [HttpPost]
    [Route("AddRepetitionPlan")]
    public async Task<IActionResult> CreateRepetitionPlan(CreateRepetitionPlanModel model)
    {
        return Ok(await _repetitionPlanService.CreateRepetitionPlanAsync(model));
    }

    [HttpPut]
    [Route("UpdateRepetitionPlan")]
    public async Task<IActionResult> UpdateRepetitionPlan(int id,UpdateRepetitionPlanModel model)
    {
        return Ok(await _repetitionPlanService.UpdateRepetitionPlanAsync(id, model));
    }

    [HttpDelete]
    [Route("DeleteRepetitionPlan")]
    public async Task<IActionResult> DeleteRepetitionPlan(int repetitionPlanId)
    {
        return Ok(await _repetitionPlanService.DeleteRepetitionPlanAsync(repetitionPlanId));
    }
}