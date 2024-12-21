using N_Tier.Application.Models;
using N_Tier.Application.Models.RepetitionPlan;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services;

public interface IRepetitionPlanService
{
    Task<CreateRepetitionPlanResponseModel> CreateRepetitionPlanAsync(CreateRepetitionPlanModel createRepetitionPlanModel);
    Task<RepetitionPlan> GetRepetitionPlanAsync(int Id);
    Task<IEnumerable<RepetitionPlanResponseModel>> GetAllRepetitionPlansAsync();
    Task<UpdateRepetitionPlanResponseModel> UpdateRepetitionPlanAsync(int id, UpdateRepetitionPlanModel updateRepetitionPlanModel);
    Task<BaseResponseModel> DeleteRepetitionPlanAsync(int id);
}