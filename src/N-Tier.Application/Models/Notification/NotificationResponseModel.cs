namespace N_Tier.Application.Models.Notification;

public class NotificationResponseModel : BaseResponseModel
{
    public int RepetitionPlanId { get; set; }
    public DateTime NotificationDate { get; set; }
    public TimeSpan NotificationTime { get; set; }
    public bool IsSend { get; set; }
    public int UserId { get; set; }
    
}