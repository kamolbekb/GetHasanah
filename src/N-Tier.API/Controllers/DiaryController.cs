using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Diary;
using N_Tier.Application.Services;
using N_Tier.Core.Entities;

namespace N_Tier.API.Controllers;
[AllowAnonymous]
public class DiaryController : ApiController
{
    private readonly IDiaryService _diaryService;

    public DiaryController (IDiaryService diaryService)
    {
        _diaryService = diaryService;
    }

    [HttpGet]
    [Route ("GetDiary")]
    public async Task<IActionResult> GetDiaryByIdAsync(Guid diaryId)
    {
        return Ok(await _diaryService.GetDiaryAsync(diaryId));
    }

    [HttpGet]
    [Route("AllDiarys")]
    [Authorize(Policy = "SuperAdminOnly")]
    public async Task<IActionResult> GetDiariesAsync()
    {
        return Ok(ApiResult<IEnumerable<DiaryResponseModel>>.Success(await _diaryService.GetAllDiarysAsync()));
    }

    [HttpGet("Api/GetDetailed/{userId}")]
    public async Task<IActionResult> GetAllDetailedDiaries()
    {
        return Ok(ApiResult<List<Diary>>.Success(await _diaryService.GetAllWithDetailsAsync()));
    }
    [HttpPost]
    [Route("AddDiary")]
    public async Task<IActionResult> CreateDiary(CreateDiaryModel model)
    {
        return Ok(await _diaryService.CreateDiaryAsync(model));
    }

    [HttpPut]
    [Route("UpdateDiary")]
    public async Task<IActionResult> UpdateDiary(Guid id,UpdateDiaryModel model)
    {
        return Ok(await _diaryService.UpdateDiaryAsync(id, model));
    }

    [HttpDelete]
    [Route("DeleteDiary")]
    public async Task<IActionResult> DeleteDiary(Guid diaryId)
    {
        return Ok(await _diaryService.DeleteDiaryAsync(diaryId));
    }
}