using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class LearnTypeRepository : BaseRepository<LearnType, Guid>, ILearnTypeRepository
{
    public LearnTypeRepository(DatabaseContext context) : base(context) { }
}