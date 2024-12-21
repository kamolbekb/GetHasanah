using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Extensions;
using N_Tier.Application.Models;
using N_Tier.Application.Models.LearnType;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class LearnTypeService : ILearnTypeService
{
    private readonly IMapper _mapper;
    private readonly ILearnTypeRepository _learnTypeRepository;

    public LearnTypeService(IMapper mapper, ILearnTypeRepository learnTypeRepository)
    {
        _mapper = mapper;
        _learnTypeRepository = learnTypeRepository;
    }

    public async Task<CreateLearnTypeResponseModel> CreateLearnTypeAsync(CreateLearnTypeModel createLearnTypeModel)
    {
        var learnType = _mapper.Map<LearnType>(createLearnTypeModel);
        var addedLearnType = await _learnTypeRepository.InsertAsync(learnType);
        return new CreateLearnTypeResponseModel
        {
            Id = addedLearnType.Id,
        };
    }
    
    public async Task<LearnType> GetLearnTypeAsync(int learnTypeId)
    {
        var storageLearnType = await _learnTypeRepository
            .SelectByIdAsync(learnTypeId);

        return await Task.FromResult(storageLearnType);
    }

    public async Task<IEnumerable<LearnTypeResponseModel>> GetAllLearnTypesAsync()
    {
        var learnTypes = _learnTypeRepository
            .SelectAll();
        return await Task.FromResult(_mapper.Map<IEnumerable<LearnTypeResponseModel>>(learnTypes));
    }

    public Task<PagedResult<LearnTypeResponseModel>> GetAllLearnTypesAsync(Options options)
    {
        object learnTypes = _learnTypeRepository
            .SelectAll()
            .ToPagedResultAsync(options);
        return Task.FromResult<PagedResult<LearnTypeResponseModel>>(_mapper.Map<PagedResult<LearnTypeResponseModel>>(learnTypes));
    }

    public async Task<UpdateLearnTypeResponseModel> UpdateLearnTypeAsync(int id, UpdateLearnTypeModel updateLearnTypeModel)
    {
        var learnType = _learnTypeRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        _mapper.Map(updateLearnTypeModel, learnType);
        var updatedLearnType = await _learnTypeRepository.UpdateAsync(learnType);
        return new UpdateLearnTypeResponseModel
        {
            Id = updatedLearnType.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteLearnTypeAsync(int id)
    {
        var learnType = _learnTypeRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        await _learnTypeRepository.DeleteAsync(learnType);
        await _learnTypeRepository.SaveChangesAsync();
        return new BaseResponseModel();

    }
}