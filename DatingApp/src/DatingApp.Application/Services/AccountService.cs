using System.Linq;
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
    private readonly ITokenService _tokenService;

    public AccountService(IUserService userService, ITokenService tokenService)
    {
      _userService = userService;
      _tokenService = tokenService;
    }

    public async Task<bool> UserNameExists(string userName)
    {
      return await _userService.UserNameExistsAsync(userName);
    }

    public async Task<UserDto> RegisterUserAsync(RegisterDto registerDto)
    {
      User user = new User
      {
        UserName = registerDto.UserName.ToLower()
      };

      SetPasswordHash(registerDto.Password, user);

      await _userService.AddUserAsync(user);

      UserDto userDto = _userService.MapToUserDto(user);

      userDto.Token = _tokenService.CreateToken(userDto);

      return userDto;
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
      userDto.Token = _tokenService.CreateToken(userDto);

      return userDto;
    }

    private bool VerifyPassword(LoginDto loginDto, User user)
    {
      using HMACSHA512 hmac = new HMACSHA512(user.PasswordSalt);
      byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

      bool isEqual = computedHash.SequenceEqual(user.PasswordHash);

      return isEqual;
    }

    private void SetPasswordHash(string password, User user)
    {
      using var hmac = new HMACSHA512();
      user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
      user.PasswordSalt = hmac.Key;
    }
  }
}
