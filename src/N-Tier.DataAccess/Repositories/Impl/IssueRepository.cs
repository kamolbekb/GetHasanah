using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class IssueRepository : BaseRepository<Issue, Guid>, IIssueRepository
{
    public IssueRepository(DatabaseContext context) : base(context) { }
}