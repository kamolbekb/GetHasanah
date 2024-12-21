using N_Tier.Application.Models;
using N_Tier.Application.Models.User;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services;

public interface IUserService
{
    Task<CreateUserResponseModel> CreateUserAsync(CreateUserModel createUserModel);
    Task<User> GetUserAsync(int Id);
    Task<IEnumerable<UserResponseModel>> GetAllUsersAsync();
    Task<UpdateUserResponseModel> UpdateUserAsync(int id, UpdateUserModel updateUserModel);
    Task<BaseResponseModel> DeleteUserAsync(int id);
}