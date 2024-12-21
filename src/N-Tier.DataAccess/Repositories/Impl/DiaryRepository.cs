using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;
namespace N_Tier.DataAccess.Repositories.Impl;
public class DiaryRepository : BaseRepository<Diary, Guid>, IDiaryRepository
{
    public DiaryRepository(DatabaseContext context) : base(context) { }
}