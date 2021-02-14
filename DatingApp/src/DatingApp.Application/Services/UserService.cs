using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Application.Interfaces.DataAccess;
using DatingApp.Application.Interfaces.Services;
using DatingApp.Domain.Entities;

namespace DatingApp.Application.Services
{
  public class UserService : IUserService
  {
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public IEnumerable<User> GetUsers()
    {
      IEnumerable<User> users = _unitOfWork.UserRepository.GetAll();
      return users;
    }

    public async Task<IEnumerable<User>> GetUsersListAsync()
    {
      IEnumerable<User> users = await _unitOfWork.UserRepository.GetAllListAsync();
      return users;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
      User user = await _unitOfWork.UserRepository.GetByIdAsync(id);
      return user;
    }
  }
}
