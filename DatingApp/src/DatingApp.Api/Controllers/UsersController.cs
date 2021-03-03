using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Application.Interfaces.Services;
using DatingApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
  public class UsersController : BaseApiController
  {
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetUsersAsync()
    {
      IEnumerable<User> users = await _userService.GetUsersListAsync();
      return Ok(users);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
      User user = await _userService.GetUserByIdAsync(id);
      return Ok(user);
    }
  }
}
