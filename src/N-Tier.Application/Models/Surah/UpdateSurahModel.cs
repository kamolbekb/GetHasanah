namespace N_Tier.Application.Models.Surah;

public class UpdateSurahModel
{
    public string Name { get; set; }
    public int AyahSize { get; set; }
}

public class UpdateSurahResponseModel : BaseResponseModel
{
}