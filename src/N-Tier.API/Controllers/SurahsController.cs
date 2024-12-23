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
}