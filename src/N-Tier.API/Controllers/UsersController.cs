using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.User;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class UsersController : ApiController
{
    private readonly IUserService _userService;

    public UsersController (IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route ("GetUser")]
    public async Task<IActionResult> GetUserByIdAsync(int userId)
    {
        return Ok(await _userService.GetUserAsync(userId));
    }

    [HttpGet]
    [Route("AllUsers")]
    
    public async Task<IActionResult> GetUsersAsync()
    {
        return Ok(ApiResult<IEnumerable<UserResponseModel>>.Success(await _userService.GetAllUsersAsync()));
    }

    [HttpPost]
    [Route("AddUser")]
    public async Task<IActionResult> CreateUser(CreateUserModel model)
    {
        return Ok(await _userService.CreateUserAsync(model));
    }

    [HttpPut]
    [Route("UpdateUser")]
    public async Task<IActionResult> UpdateUser(int id,UpdateUserModel model)
    {
        return Ok(await _userService.UpdateUserAsync(id, model));
    }

    [HttpDelete]
    [Route("DeleteUser")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        return Ok(await _userService.DeleteUserAsync(userId));
    }
}