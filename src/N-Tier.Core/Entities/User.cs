namespace N_Tier.Core.Entities;

public class User
{
    public int Id { get; set; }
    public long TelegramId { get; set; }
    public string FullName { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public ICollection<Issue> Issues { get; set; }
    public ICollection<RepetitionPlan> RepetitionPlans { get; set; }
    public ICollection<Notification> Notifications { get; set; }
}