using System.Threading.Tasks;
using DatingApp.Domain.Entities;

namespace DatingApp.Application.Interfaces.DataAccess
{
  public interface IUserRepository : IRepository<User>
  {
    Task<bool> UserNameExistsAsync(string userName);
    Task<User> GetUserByUserNameAsync(string userName);
  }
}