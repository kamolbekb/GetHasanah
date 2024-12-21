using N_Tier.Application.Models;
using N_Tier.Application.Models.Contact;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services;

public interface IContactService
{
    Task<CreateContactResponseModel> CreateContactAsync(CreateContactModel createContactModel);
    Task<Contact> GetContactAsync(Guid contactId);
    Task<IEnumerable<ContactResponseModel>> GetAllContactsAsync();
    //Task<List<Contact>> GetAllWithIQueryableAsync();
    //Task<PagedResult<Contact>> GetAllAsync(Options options);
    Task<PagedResult<ContactResponseModel>> GetAllContactsAsync(Options options);
    Task<UpdateContactResponseModel> UpdateContactAsync(Guid id, UpdateContactModel updateContactModel);
    Task<BaseResponseModel> DeleteContactAsync(Guid id);
}