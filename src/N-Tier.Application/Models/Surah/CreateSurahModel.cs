namespace N_Tier.Application.Models.Surah;

public class CreateSurahModel
{
    public string Name { get; set; }
    public int AyahSize { get; set; }
}

public class CreateSurahResponseModel : BaseResponseModel { }