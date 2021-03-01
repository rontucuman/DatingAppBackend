using System;
using System.Threading;
using System.Threading.Tasks;
using DatingApp.Application.Interfaces.DataAccess;
using DatingApp.Domain.Entities;
using DatingApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.DataAccess
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(DatingAppContext context) : base(context)
    {
    }

    public async Task<bool> UserNameExistsAsync(string userName)
    {
      return await Entities.AnyAsync(x => x.UserName.ToLower().Equals(userName.ToLower()));
    }

    public async Task<User> GetUserByUserNameAsync(string userName)
    {
      return await Entities.SingleOrDefaultAsync(x => x.UserName.ToLower().Equals(userName.ToLower()));
    }
  }
}