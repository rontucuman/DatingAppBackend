using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Application.Interfaces.Services;
using DatingApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
      IEnumerable<User> users = await _userService.GetUsersListAsync();
      return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
      User user = await _userService.GetUserByIdAsync(id);
      return Ok(user);
    }
  }
}
