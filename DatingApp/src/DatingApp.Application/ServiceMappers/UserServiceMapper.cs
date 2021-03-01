using DatingApp.Application.Dtos;
using DatingApp.Domain.Entities;

namespace DatingApp.Application.ServiceMappers
{
  public class UserServiceMapper : IUserServiceMapper
  {
    public UserDto MapToUserDto(User user)
    {
      UserDto dto = new UserDto
      {
        UserName = user.UserName
      };

      return dto;
    }

    public void UpdateUserEntity(User user, UserDto userDto)
    {
      user.UserName = userDto.UserName;
    }
  }
}