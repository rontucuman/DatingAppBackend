using System.Threading.Tasks;
using DatingApp.Application.Interfaces.DataAccess;
using DatingApp.Domain.Entities;
using DatingApp.Infrastructure.Persistence;

namespace DatingApp.Infrastructure.DataAccess
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly DatingAppContext _context;
    private IRepository<User> _userRepository;

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

    public IRepository<User> UserRepository => _userRepository ??= new BaseRepository<User>(_context);

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