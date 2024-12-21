using N_Tier.Application.Models;
using N_Tier.Application.Models.Notification;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services;

public interface INotificationService
{
    Task<CreateNotificationResponseModel> CreateNotificationAsync(CreateNotificationModel createNotificationModel);
    Task<Notification> GetNotificationAsync(int Id);
    Task<IEnumerable<NotificationResponseModel>> GetAllNotificationsAsync();
    Task<UpdateNotificationResponseModel> UpdateNotificationAsync(int id, UpdateNotificationModel updateNotificationModel);
    Task<BaseResponseModel> DeleteNotificationAsync(int id);
}