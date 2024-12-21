namespace N_Tier.Application.Models.RepetitionPlan;

public class CreateRepetitionPlanModel
{
    public int IssuesId { get; set; }
    public DateTime RepetitionDate { get; set; }
    public TimeSpan RepetitionTime { get; set; }
    public long RepetitionCount { get; set; }
    public int RepetitionDay { get; set; }
    public bool IsCompleted { get; set; }
    public bool RemindMe { get; set; }
    public int UserId { get; set; }
}

public class CreateRepetitionPlanResponseModel : BaseResponseModel { }