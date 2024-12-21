namespace N_Tier.Core.Entities;

public class Notification
{
    public int Id { get; set; }
    public int RepetitionPlanId { get; set; }
    public DateTime NotificationDate { get; set; }
    public TimeSpan NotificationTime { get; set; }
    public bool IsSend { get; set; }
    public int UserId { get; set; }

    // Navigation properties
    public RepetitionPlan RepetitionPlan { get; set; }
    public User User { get; set; }
}