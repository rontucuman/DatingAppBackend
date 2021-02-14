using System;
using System.Threading.Tasks;
using DatingApp.Domain.Entities;

namespace DatingApp.Application.Interfaces.DataAccess
{
  public interface IUnitOfWork : IDisposable
  {
    public IRepository<User> UserRepository { get; }

    void SaveChanges();
    Task SaveChangesAsync();
  }
}
