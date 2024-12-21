namespace N_Tier.Core.Entities;

public class Issue
{
    public int Id { get; set; }
    public int LearnTypeId { get; set; }
    public int? SurahId { get; set; }
    public int From { get; set; }
    public int To { get; set; }
    public DateTime DateLearned { get; set; }
    public TimeSpan LearningTime { get; set; }
    public long RepetitionCount { get; set; }
    public int UserId { get; set; }

    // Navigation properties
    public LearnType LearnType { get; set; }
    public Surah Surah { get; set; }
    public User User { get; set; }
    public ICollection<RepetitionPlan> RepetitionPlans { get; set; }
}