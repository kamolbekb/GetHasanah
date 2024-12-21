using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class RepetitionPlanRepository : BaseRepository<RepetitionPlan, Guid>, IRepetitionPlanRepository
{
    public RepetitionPlanRepository(DatabaseContext context) : base(context) { }
}