using DatingApp.Application.Interfaces.Services;
using DatingApp.Application.ServiceMappers;
using DatingApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.Application.Extensions
{
  public static class ServiceCollectionExtension
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddTransient<IUserService, UserService>()
        .AddTransient<IAccountService, AccountService>()
        .AddTransient<IUserServiceMapper, UserServiceMapper>();

      return services;
    }
  }
}