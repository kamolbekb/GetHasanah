using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Surah;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class SurahsController : ApiController
{
    private readonly ISurahService _surahService;

    public SurahsController (ISurahService surahService)
    {
        _surahService = surahService;
    }

    [HttpGet]
    [Route ("GetSurah")]
    public async Task<IActionResult> GetSurahByIdAsync(int surahId)
    {
        return Ok(await _surahService.GetSurahAsync(surahId));
    }

    [HttpGet]
    [Route("AllSurahs")]
    
    public async Task<IActionResult> GetSurahsAsync()
    {
        return Ok(ApiResult<IEnumerable<SurahResponseModel>>.Success(await _surahService.GetAllSurahsAsync()));
    }

    [HttpPost]
    [Route("AddSurah")]
    public async Task<IActionResult> CreateSurah(CreateSurahModel model)
    {
        return Ok(await _surahService.CreateSurahAsync(model));
    }

    [HttpPut]
    [Route("UpdateSurah")]
    public async Task<IActionResult> UpdateSurah(int id,UpdateSurahModel model)
    {
        return Ok(await _surahService.UpdateSurahAsync(id, model));
    }

    [HttpDelete]
    [Route("DeleteSurah")]
    public async Task<IActionResult> DeleteSurah(int surahId)
    {
        return Ok(await _surahService.DeleteSurahAsync(surahId));
    }
}