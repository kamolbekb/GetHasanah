using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Extensions;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Notification;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class NotificationService : INotificationService
{
    private readonly IMapper _mapper;
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(IMapper mapper, INotificationRepository notificationRepository)
    {
        _mapper = mapper;
        _notificationRepository = notificationRepository;
    }

    public async Task<CreateNotificationResponseModel> CreateNotificationAsync(CreateNotificationModel createNotificationModel)
    {
        var notification = _mapper.Map<Notification>(createNotificationModel);
        var addedNotification = await _notificationRepository.InsertAsync(notification);
        return new CreateNotificationResponseModel
        {
            Id = addedNotification.Id,
        };
    }
    
    public async Task<Notification> GetNotificationAsync(int notificationId)
    {
        var storageNotification = await _notificationRepository
            .SelectByIdAsync(notificationId);

        return await Task.FromResult(storageNotification);
    }

    public async Task<IEnumerable<NotificationResponseModel>> GetAllNotificationsAsync()
    {
        var notifications = _notificationRepository
            .SelectAll();
        return await Task.FromResult(_mapper.Map<IEnumerable<NotificationResponseModel>>(notifications));
    }

    public Task<PagedResult<NotificationResponseModel>> GetAllNotificationsAsync(Options options)
    {
        object notifications = _notificationRepository
            .SelectAll()
            .ToPagedResultAsync(options);
        return Task.FromResult<PagedResult<NotificationResponseModel>>(_mapper.Map<PagedResult<NotificationResponseModel>>(notifications));
    }

    public async Task<UpdateNotificationResponseModel> UpdateNotificationAsync(int id, UpdateNotificationModel updateNotificationModel)
    {
        var notification = _notificationRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        _mapper.Map(updateNotificationModel, notification);
        var updatedNotification = await _notificationRepository.UpdateAsync(notification);
        return new UpdateNotificationResponseModel
        {
            Id = updatedNotification.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteNotificationAsync(int id)
    {
        var notification = _notificationRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        await _notificationRepository.DeleteAsync(notification);
        await _notificationRepository.SaveChangesAsync();
        return new BaseResponseModel();

    }
}