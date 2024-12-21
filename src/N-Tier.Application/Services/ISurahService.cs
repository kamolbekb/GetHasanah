using N_Tier.Application.Models;
using N_Tier.Application.Models.Surah;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services;

public interface ISurahService
{
    Task<CreateSurahResponseModel> CreateSurahAsync(CreateSurahModel createSurahModel);
    Task<Surah> GetSurahAsync(int Id);
    Task<IEnumerable<SurahResponseModel>> GetAllSurahsAsync();
    Task<UpdateSurahResponseModel> UpdateSurahAsync(int id, UpdateSurahModel updateSurahModel);
    Task<BaseResponseModel> DeleteSurahAsync(int id);
}