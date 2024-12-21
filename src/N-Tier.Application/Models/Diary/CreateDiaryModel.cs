namespace N_Tier.Application.Models.Diary;

public class CreateDiaryModel
{
    public Guid StudentId { get; set; }
}

public class CreateDiaryResponseModel : BaseResponseModel { }