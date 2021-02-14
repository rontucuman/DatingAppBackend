using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Application.Interfaces.DataAccess;
using DatingApp.Domain.Entities;
using DatingApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.DataAccess
{
  internal class BaseRepository<T> : IRepository<T> where T : BaseEntity
  {
    private readonly DbSet<T> _entities;

    public BaseRepository(DatingAppContext context)
    {
      if (context == null) throw new ArgumentNullException(nameof(context));
      _entities = context.Set<T>();
    }
    public IEnumerable<T> GetAll()
    {
      return _entities.AsEnumerable();
    }

    public async Task<IEnumerable<T>> GetAllListAsync()
    {
      return await _entities.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _entities.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
      await _entities.AddAsync(entity);
    }

    public void Update(T entity)
    {
      _entities.Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
      T entity = await GetByIdAsync(id);
      _entities.Remove(entity);
    }
  }
}
