using DatingApp.Application.Dtos;

namespace DatingApp.Application.Interfaces.Services
{
  public interface ITokenService
  {
    string CreateToken(UserDto userDto);
  }
}