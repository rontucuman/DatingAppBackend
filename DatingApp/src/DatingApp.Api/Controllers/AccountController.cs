using System.Threading.Tasks;
using DatingApp.Application.Dtos;
using DatingApp.Application.Dtos.Account;
using DatingApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
  public class AccountController : BaseApiController
  {
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
      _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
      if (await _accountService.UserNameExists(registerDto.UserName))
      {
        return BadRequest($"UserName '{registerDto.UserName}' already exists.");
      }

      UserDto userDto = await _accountService.RegisterUserAsync(registerDto);

      return Ok(userDto);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
      UserDto userDto = await _accountService.LoginUserAsync(loginDto);

      if (userDto == null)
      {
        return Unauthorized("Invalid username or password.");
      }

      return Ok(userDto);
    }
  }
}
