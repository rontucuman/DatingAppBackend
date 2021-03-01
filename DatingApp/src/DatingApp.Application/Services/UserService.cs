using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Application.Dtos;
using DatingApp.Application.Interfaces.DataAccess;
using DatingApp.Application.Interfaces.Services;
using DatingApp.Application.ServiceMappers;
using DatingApp.Domain.Entities;

namespace DatingApp.Application.Services
{
  public class UserService : IUserService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserServiceMapper _userMapper;

    public UserService(IUnitOfWork unitOfWork, IUserServiceMapper userMapper)
    {
      _unitOfWork = unitOfWork;
      _userMapper = userMapper;
    }

    public IEnumerable<User> GetUsers()
    {
      IEnumerable<User> users = _unitOfWork.UserRepository.GetAll();
      return users;
    }

    public async Task<IEnumerable<User>> GetUsersListAsync()
    {
      IEnumerable<User> users = await _unitOfWork.UserRepository.GetAllListAsync();
      return users;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
      User user = await _unitOfWork.UserRepository.GetByIdAsync(id);
      return user;
    }

    public async Task<User> GetUserByUserNameAsync(string userName)
    {
      User user = await _unitOfWork.UserRepository.GetUserByUserNameAsync(userName);
      return user;
    }

    public async Task AddUserAsync(User user)
    {
      await _unitOfWork.UserRepository.AddAsync(user);
      await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> UserNameExistsAsync(string userName)
    {
      return await _unitOfWork.UserRepository.UserNameExistsAsync(userName);
    }

    public UserDto MapToUserDto(User user)
    {
      return _userMapper.MapToUserDto(user);
    }

    public void UpdateUserEntity(User user, UserDto userDto)
    {
      _userMapper.UpdateUserEntity(user, userDto);
    }
  }
}
