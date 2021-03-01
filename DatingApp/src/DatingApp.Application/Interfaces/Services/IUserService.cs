using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Application.Dtos;
using DatingApp.Domain.Entities;

namespace DatingApp.Application.Interfaces.Services
{
  public interface IUserService
  {
    IEnumerable<User> GetUsers();
    Task<IEnumerable<User>> GetUsersListAsync();
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByUserNameAsync(string userName);
    Task AddUserAsync(User user);
    Task<bool> UserNameExistsAsync(string userName);
    UserDto MapToUserDto(User user);
    void UpdateUserEntity(User user, UserDto userDto);
  }
}
