using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class SurahRepository : BaseRepository<Surah, Guid>, ISurahRepository
{
    public SurahRepository(DatabaseContext context) : base(context) { }
}