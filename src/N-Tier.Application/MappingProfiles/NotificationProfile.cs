using AutoMapper;
using N_Tier.Application.Models.Notification;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class NotificationProfile : Profile
{
    public NotificationProfile()
    {
        CreateMap<CreateNotificationModel, Notification>();

        CreateMap<Notification, NotificationResponseModel>();
        CreateMap<UpdateNotificationModel, Notification>();
    }
}