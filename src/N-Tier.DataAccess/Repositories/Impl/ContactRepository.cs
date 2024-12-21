using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;
namespace N_Tier.DataAccess.Repositories.Impl;
public class ContactRepository : BaseRepository<Contact, Guid>, IContactRepository
{
    public ContactRepository(DatabaseContext context) : base(context) { }
}