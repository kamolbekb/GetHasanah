namespace N_Tier.Application.Models.Issue;

public class IssueResponseModel : BaseResponseModel
{
    public int LearnTypeId { get; set; }
    public int? SurahId { get; set; }
    public int From { get; set; }
    public int To { get; set; }
    public DateTime DateLearned { get; set; }
    public TimeSpan LearningTime { get; set; }
    public long RepetitionCount { get; set; }
    public int UserId { get; set; }
}