using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Domain.Entities;

namespace DatingApp.Application.Interfaces.DataAccess
{
  public interface IRepository<T> where T : BaseEntity
  {
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllListAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    void Update(T entity);
    Task DeleteAsync(int id);
  }
}
