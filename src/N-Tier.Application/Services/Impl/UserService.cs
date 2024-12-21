using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Extensions;
using N_Tier.Application.Models;
using N_Tier.Application.Models.User;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<CreateUserResponseModel> CreateUserAsync(CreateUserModel createUserModel)
    {
        var user = _mapper.Map<User>(createUserModel);
        user.CreatedAt = DateTime.UtcNow;
        var addedUser = await _userRepository.InsertAsync(user);
        return new CreateUserResponseModel
        {
            Id = addedUser.Id,
        };
    }
    
    public async Task<User> GetUserAsync(int userId)
    {
        var storageUser = await _userRepository
            .SelectByIdAsync(userId);

        return await Task.FromResult(storageUser);
    }

    public async Task<IEnumerable<UserResponseModel>> GetAllUsersAsync()
    {
        var users = _userRepository
            .SelectAll();
        return await Task.FromResult(_mapper.Map<IEnumerable<UserResponseModel>>(users));
    }

    public Task<PagedResult<UserResponseModel>> GetAllUsersAsync(Options options)
    {
        object users = _userRepository
            .SelectAll()
            .ToPagedResultAsync(options);
        return Task.FromResult<PagedResult<UserResponseModel>>(_mapper.Map<PagedResult<UserResponseModel>>(users));
    }

    public async Task<UpdateUserResponseModel> UpdateUserAsync(int id, UpdateUserModel updateUserModel)
    {
        var user = _userRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        _mapper.Map(updateUserModel, user);
        var updatedUser = await _userRepository.UpdateAsync(user);
        return new UpdateUserResponseModel
        {
            Id = updatedUser.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteUserAsync(int id)
    {
        var user = _userRepository.SelectAll()
            .FirstOrDefault(d => d.Id == id);
        await _userRepository.DeleteAsync(user);
        await _userRepository.SaveChangesAsync();
        return new BaseResponseModel();

    }
}