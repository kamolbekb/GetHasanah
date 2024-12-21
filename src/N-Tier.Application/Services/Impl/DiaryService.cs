using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Extensions;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Diary;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class DiaryService : IDiaryService
{
    private readonly IMapper _mapper;
    private readonly IDiaryRepository _diaryRepository;

    public DiaryService(IMapper mapper, IDiaryRepository diaryRepository)
    {
        _mapper = mapper;
        _diaryRepository = diaryRepository;
    }

    public async Task<CreateDiaryResponseModel> CreateDiaryAsync(CreateDiaryModel createDiaryModel)
    {
        var diary = _mapper.Map<Diary>(createDiaryModel);
        var addedDiary = await _diaryRepository.InsertAsync(diary);
        return new CreateDiaryResponseModel
        {
            Id = addedDiary.Id,
        };
    }
    
    public async Task<Diary> GetDiaryAsync(Guid diaryId)
    {
        var storageDiary = await _diaryRepository
            .SelectByIdAsync(diaryId);

        return await Task.FromResult(storageDiary);
    }

    public async Task<IEnumerable<DiaryResponseModel>> GetAllDiarysAsync()
    {
        var diarys = _diaryRepository
            .SelectAll();
        return await Task.FromResult(_mapper.Map<IEnumerable<DiaryResponseModel>>(diarys));
    }

    public async Task<List<Diary>> GetAllWithDetailsAsync()
    {
        return await _diaryRepository.SelectAllWithIncludesAsync("DiaryRecord","Student");
    }

    public async Task<UpdateDiaryResponseModel> UpdateDiaryAsync(Guid id, UpdateDiaryModel updateDiaryModel)
    {
        var diary = _diaryRepository.SelectAll().FirstOrDefault(i=>i.Id == id);
        _mapper.Map(updateDiaryModel, diary);
        var updatedDiary = await _diaryRepository.UpdateAsync(diary);
        return new UpdateDiaryResponseModel
        {
            Id = updatedDiary.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteDiaryAsync(Guid id)
    {
        var diary = _diaryRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        await _diaryRepository.DeleteAsync(diary);
        await _diaryRepository.SaveChangesAsync();
        return new BaseResponseModel();

    }
}