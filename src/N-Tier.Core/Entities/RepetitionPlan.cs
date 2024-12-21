namespace N_Tier.Core.Entities;

public class RepetitionPlan
{
    public int Id { get; set; }
    public int IssuesId { get; set; }
    public DateTime RepetitionDate { get; set; }
    public TimeSpan RepetitionTime { get; set; }
    public long RepetitionCount { get; set; }
    public int RepetitionDay { get; set; }
    public bool IsCompleted { get; set; }
    public bool RemindMe { get; set; }
    public int UserId { get; set; }

    // Navigation properties
    public Issue Issue { get; set; }
    public User User { get; set; }
    public ICollection<Notification> Notifications { get; set; }
}