namespace N_Tier.Application.Models.User;

public class UserResponseModel : BaseResponseModel
{
    public long TelegramId { get; set; }
    public string FullName { get; set; }
    public DateTime CreatedAt { get; set; }
}