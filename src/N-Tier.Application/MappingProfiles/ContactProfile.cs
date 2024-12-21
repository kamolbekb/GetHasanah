using AutoMapper;
using N_Tier.Application.Models.Contact;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<CreateContactModel, Contact>();

        CreateMap<Contact, ContactResponseModel>();
        CreateMap<UpdateContactModel, Contact>();
    }
}