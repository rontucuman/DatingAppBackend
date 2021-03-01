using DatingApp.Application.Interfaces.DataAccess;
using DatingApp.Application.Interfaces.Services;
using DatingApp.Application.ServiceMappers;
using DatingApp.Application.Services;
using DatingApp.Infrastructure.DataAccess;
using DatingApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.Infrastructure.Extensions
{
  public static class ServiceCollectionExtension
  {
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config)
    {
      services.AddDbContext<DatingAppContext>(options =>
      {
        options.UseSqlServer(config.GetConnectionString("DatingApp"));
      });

      return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddTransient<IUserService, UserService>();
      services.AddTransient<IAccountService, AccountService>();
      services.AddTransient<IUserServiceMapper, UserServiceMapper>();

      return services;
    }

    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
      services.AddTransient<IUnitOfWork, UnitOfWork>();
      
      return services;
    }
  }
}
