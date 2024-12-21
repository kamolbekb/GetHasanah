using N_Tier.Application.Models;
using N_Tier.Application.Models.LearnType;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services;

public interface ILearnTypeService
{
    Task<CreateLearnTypeResponseModel> CreateLearnTypeAsync(CreateLearnTypeModel createLearnTypeModel);
    Task<LearnType> GetLearnTypeAsync(int Id);
    Task<IEnumerable<LearnTypeResponseModel>> GetAllLearnTypesAsync();
    Task<UpdateLearnTypeResponseModel> UpdateLearnTypeAsync(int id, UpdateLearnTypeModel updateLearnTypeModel);
    Task<BaseResponseModel> DeleteLearnTypeAsync(int id);
}