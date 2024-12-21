using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Notification;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class NotificationsController : ApiController
{
    private readonly INotificationService _notificationService;

    public NotificationsController (INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    [Route ("GetNotification")]
    public async Task<IActionResult> GetNotificationByIdAsync(int notificationId)
    {
        return Ok(await _notificationService.GetNotificationAsync(notificationId));
    }

    [HttpGet]
    [Route("AllNotifications")]
    
    public async Task<IActionResult> GetNotificationsAsync()
    {
        return Ok(ApiResult<IEnumerable<NotificationResponseModel>>.Success(await _notificationService.GetAllNotificationsAsync()));
    }

    [HttpPost]
    [Route("AddNotification")]
    public async Task<IActionResult> CreateNotification(CreateNotificationModel model)
    {
        return Ok(await _notificationService.CreateNotificationAsync(model));
    }

    [HttpPut]
    [Route("UpdateNotification")]
    public async Task<IActionResult> UpdateNotification(int id,UpdateNotificationModel model)
    {
        return Ok(await _notificationService.UpdateNotificationAsync(id, model));
    }

    [HttpDelete]
    [Route("DeleteNotification")]
    public async Task<IActionResult> DeleteNotification(int notificationId)
    {
        return Ok(await _notificationService.DeleteNotificationAsync(notificationId));
    }
}