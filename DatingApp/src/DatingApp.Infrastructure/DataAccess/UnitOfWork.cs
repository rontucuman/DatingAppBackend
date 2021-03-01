using System.Threading.Tasks;
using DatingApp.Application.Interfaces.DataAccess;
using DatingApp.Domain.Entities;
using DatingApp.Infrastructure.Persistence;

namespace DatingApp.Infrastructure.DataAccess
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly DatingAppContext _context;
    private IUserRepository _userRepository;

    public UnitOfWork(DatingAppContext context)
    {
      _context = context;
    }

    public async void Dispose()
    {
      if (_context != null)
      {
        await _context.DisposeAsync();
      }
    }

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

    public void SaveChanges()
    {
      _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
      await _context.SaveChangesAsync();
    }
  }
}