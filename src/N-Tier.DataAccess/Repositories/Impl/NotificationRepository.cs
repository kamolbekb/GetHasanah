using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class NotificationRepository : BaseRepository<Notification, Guid>, INotificationRepository
{
    public NotificationRepository(DatabaseContext context) : base(context) { }
}