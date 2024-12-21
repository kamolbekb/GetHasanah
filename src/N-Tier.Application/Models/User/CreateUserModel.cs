namespace N_Tier.Application.Models.User;

public class CreateUserModel
{
    public long TelegramId { get; set; }
    public string FullName { get; set; }
}

public class CreateUserResponseModel : BaseResponseModel { }