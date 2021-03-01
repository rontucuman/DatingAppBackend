using DatingApp.Application.Dtos;
using DatingApp.Domain.Entities;

namespace DatingApp.Application.ServiceMappers
{
  public interface IUserServiceMapper
  {
    UserDto MapToUserDto(User user);
    void UpdateUserEntity(User user, UserDto userDto);
  }
}