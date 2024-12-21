using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Contact;
using N_Tier.Application.Services;
using N_Tier.Core.Entities;

namespace N_Tier.API.Controllers;

public class ContactsController : ApiController
{
    private readonly IContactService _contactService;

    public ContactsController (IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    [Route ("GetContact")]
    public async Task<IActionResult> GetContactByIdAsync(Guid contactId)
    {
        return Ok(await _contactService.GetContactAsync(contactId));
    }

    [HttpGet]
    [Route("AllContacts")]
    [Authorize(Policy = "SuperAdminOnly")]
    
    public async Task<IActionResult> GetContactsAsync()
    {
        return Ok(ApiResult<IEnumerable<ContactResponseModel>>.Success(await _contactService.GetAllContactsAsync()));
    }

    [HttpPost]
    [Route("AddContact")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateContact(CreateContactModel model)
    {
        return Ok(await _contactService.CreateContactAsync(model));
    }

    [HttpPut]
    [Route("UpdateContact")]
    public async Task<IActionResult> UpdateContact(Guid id,UpdateContactModel model)
    {
        return Ok(await _contactService.UpdateContactAsync(id, model));
    }

    [HttpDelete]
    [Route("DeleteContact")]
    public async Task<IActionResult> DeleteContact(Guid contactId)
    {
        return Ok(await _contactService.DeleteContactAsync(contactId));
    }
}