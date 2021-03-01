using System.Threading.Tasks;
using DatingApp.Application.Dtos;
using DatingApp.Application.Dtos.Account;

namespace DatingApp.Application.Interfaces.Services
{
  public interface IAccountService
  {
    Task<bool> UserNameExists(string userName);
    Task RegisterUserAsync(RegisterDto registerDto);
    Task<UserDto> LoginUserAsync(LoginDto loginDto);
  }
}
