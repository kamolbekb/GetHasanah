using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Extensions;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Contact;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class ContactService : IContactService
{
    private readonly IMapper _mapper;
    private readonly IContactRepository _contactRepository;

    public ContactService(IMapper mapper, IContactRepository contactRepository)
    {
        _mapper = mapper;
        _contactRepository = contactRepository;
    }

    public async Task<CreateContactResponseModel> CreateContactAsync(CreateContactModel createContactModel)
    {
        var contact = _mapper.Map<Contact>(createContactModel);
        var addedContact = await _contactRepository.InsertAsync(contact);
        return new CreateContactResponseModel
        {
            Id = addedContact.Id,
        };
    }
    
    public async Task<Contact> GetContactAsync(Guid contactId)
    {
        var storageContact = await _contactRepository
            .SelectByIdAsync(contactId);

        return await Task.FromResult(storageContact);
    }

    public async Task<IEnumerable<ContactResponseModel>> GetAllContactsAsync()
    {
        var contacts = _contactRepository
            .SelectAll();
        return await Task.FromResult(_mapper.Map<IEnumerable<ContactResponseModel>>(contacts));
    }

    public Task<PagedResult<ContactResponseModel>> GetAllContactsAsync(Options options)
    {
        object contacts = _contactRepository
            .SelectAll()
            .ToPagedResultAsync(options);
        return Task.FromResult<PagedResult<ContactResponseModel>>(_mapper.Map<PagedResult<ContactResponseModel>>(contacts));
    }

    public async Task<UpdateContactResponseModel> UpdateContactAsync(Guid id, UpdateContactModel updateContactModel)
    {
        var contact = _contactRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        _mapper.Map(updateContactModel, contact);
        var updatedContact = await _contactRepository.UpdateAsync(contact);
        return new UpdateContactResponseModel
        {
            Id = updatedContact.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteContactAsync(Guid id)
    {
        var contact = _contactRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        await _contactRepository.DeleteAsync(contact);
        await _contactRepository.SaveChangesAsync();
        return new BaseResponseModel();

    }
}