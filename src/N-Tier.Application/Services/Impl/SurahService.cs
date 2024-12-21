using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Extensions;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Surah;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class SurahService : ISurahService
{
    private readonly IMapper _mapper;
    private readonly ISurahRepository _surahRepository;

    public SurahService(IMapper mapper, ISurahRepository surahRepository)
    {
        _mapper = mapper;
        _surahRepository = surahRepository;
    }

    public async Task<CreateSurahResponseModel> CreateSurahAsync(CreateSurahModel createSurahModel)
    {
        var surah = _mapper.Map<Surah>(createSurahModel);
        var addedSurah = await _surahRepository.InsertAsync(surah);
        return new CreateSurahResponseModel
        {
            Id = addedSurah.Id,
        };
    }
    
    public async Task<Surah> GetSurahAsync(int surahId)
    {
        var storageSurah = await _surahRepository
            .SelectByIdAsync(surahId);

        return await Task.FromResult(storageSurah);
    }

    public async Task<IEnumerable<SurahResponseModel>> GetAllSurahsAsync()
    {
        var surahs = _surahRepository
            .SelectAll();
        return await Task.FromResult(_mapper.Map<IEnumerable<SurahResponseModel>>(surahs));
    }

    public Task<PagedResult<SurahResponseModel>> GetAllSurahsAsync(Options options)
    {
        object surahs = _surahRepository
            .SelectAll()
            .ToPagedResultAsync(options);
        return Task.FromResult<PagedResult<SurahResponseModel>>(_mapper.Map<PagedResult<SurahResponseModel>>(surahs));
    }

    public async Task<UpdateSurahResponseModel> UpdateSurahAsync(int id, UpdateSurahModel updateSurahModel)
    {
        var surah = _surahRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        _mapper.Map(updateSurahModel, surah);
        var updatedSurah = await _surahRepository.UpdateAsync(surah);
        return new UpdateSurahResponseModel
        {
            Id = updatedSurah.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteSurahAsync(int id)
    {
        var surah = _surahRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        await _surahRepository.DeleteAsync(surah);
        await _surahRepository.SaveChangesAsync();
        return new BaseResponseModel();

    }
}