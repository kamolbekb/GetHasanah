namespace N_Tier.Application.Models.Contact;

public class CreateContactModel
{
    public string SocialMedia { get; set; }
    public string Link { get; set; }
}

public class CreateContactResponseModel : BaseResponseModel { }