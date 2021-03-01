using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Application.Dtos;
using DatingApp.Application.Dtos.Account;
using DatingApp.Application.Interfaces.Services;
using DatingApp.Domain.Entities;

namespace DatingApp.Application.Services
{
  public class AccountService : IAccountService
  {
    private readonly IUserService _userService;

    public AccountService(IUserService userService)
    {
      _userService = userService;
    }
    
    public async Task<bool> UserNameExists(string userName)
    {
      return await _userService.UserNameExistsAsync(userName);
    }

    public async Task RegisterUserAsync(RegisterDto registerDto)
    {
      User user = new User
      {
        UserName = registerDto.UserName.ToLower()
      };

      SetPasswordHash(registerDto.Password, user);

      await _userService.AddUserAsync(user);
    }

    public async Task<UserDto> LoginUserAsync(LoginDto loginDto)
    {
      User user = await _userService.GetUserByUserNameAsync(loginDto.UserName);

      if (user == null)
      {
        return null;
      }

      bool isValid = VerifyPassword(loginDto, user);

      if (!isValid)
      {
        return null;
      }

      UserDto userDto = _userService.MapToUserDto(user);

      return userDto;
    }

    private bool VerifyPassword(LoginDto loginDto, User user)
    {
      using HMACSHA512 hmac = new HMACSHA512(user.PasswordSalt);
      byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

      for (int i = 0; i < computedHash.Length; i++)
      {
        if (computedHash[i] != user.PasswordHash[i])
        {
          return false;
        }
      }

      return true;
    }

    private void SetPasswordHash(string password, User user)
    {
      using var hmac = new HMACSHA512();
      user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
      user.PasswordSalt = hmac.Key;
    }
  }
}
