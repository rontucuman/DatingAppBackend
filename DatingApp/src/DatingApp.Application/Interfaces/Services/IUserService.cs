using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Domain.Entities;

namespace DatingApp.Application.Interfaces.Services
{
  public interface IUserService
  {
    IEnumerable<User> GetUsers();
    Task<IEnumerable<User>> GetUsersListAsync();
    Task<User> GetUserByIdAsync(int id);
  }
}
