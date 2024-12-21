using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Extensions;
using N_Tier.Application.Models;
using N_Tier.Application.Models.RepetitionPlan;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class RepetitionPlanService : IRepetitionPlanService
{
    private readonly IMapper _mapper;
    private readonly IRepetitionPlanRepository _repetitionPlanRepository;

    public RepetitionPlanService(IMapper mapper, IRepetitionPlanRepository repetitionPlanRepository)
    {
        _mapper = mapper;
        _repetitionPlanRepository = repetitionPlanRepository;
    }

    public async Task<CreateRepetitionPlanResponseModel> CreateRepetitionPlanAsync(CreateRepetitionPlanModel createRepetitionPlanModel)
    {
        var repetitionPlan = _mapper.Map<RepetitionPlan>(createRepetitionPlanModel);
        var addedRepetitionPlan = await _repetitionPlanRepository.InsertAsync(repetitionPlan);
        return new CreateRepetitionPlanResponseModel
        {
            Id = addedRepetitionPlan.Id,
        };
    }
    
    public async Task<RepetitionPlan> GetRepetitionPlanAsync(int repetitionPlanId)
    {
        var storageRepetitionPlan = await _repetitionPlanRepository
            .SelectByIdAsync(repetitionPlanId);

        return await Task.FromResult(storageRepetitionPlan);
    }

    public async Task<IEnumerable<RepetitionPlanResponseModel>> GetAllRepetitionPlansAsync()
    {
        var repetitionPlans = _repetitionPlanRepository
            .SelectAll();
        return await Task.FromResult(_mapper.Map<IEnumerable<RepetitionPlanResponseModel>>(repetitionPlans));
    }

    public Task<PagedResult<RepetitionPlanResponseModel>> GetAllRepetitionPlansAsync(Options options)
    {
        object repetitionPlans = _repetitionPlanRepository
            .SelectAll()
            .ToPagedResultAsync(options);
        return Task.FromResult<PagedResult<RepetitionPlanResponseModel>>(_mapper.Map<PagedResult<RepetitionPlanResponseModel>>(repetitionPlans));
    }

    public async Task<UpdateRepetitionPlanResponseModel> UpdateRepetitionPlanAsync(int id, UpdateRepetitionPlanModel updateRepetitionPlanModel)
    {
        var repetitionPlan = _repetitionPlanRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        _mapper.Map(updateRepetitionPlanModel, repetitionPlan);
        var updatedRepetitionPlan = await _repetitionPlanRepository.UpdateAsync(repetitionPlan);
        return new UpdateRepetitionPlanResponseModel
        {
            Id = updatedRepetitionPlan.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteRepetitionPlanAsync(int id)
    {
        var repetitionPlan = _repetitionPlanRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        await _repetitionPlanRepository.DeleteAsync(repetitionPlan);
        await _repetitionPlanRepository.SaveChangesAsync();
        return new BaseResponseModel();

    }
}