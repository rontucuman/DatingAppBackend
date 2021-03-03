using System.Text;
using DatingApp.Application.Interfaces.DataAccess;
using DatingApp.Application.Interfaces.Services;
using DatingApp.Infrastructure.DataAccess;
using DatingApp.Infrastructure.Persistence;
using DatingApp.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.Infrastructure.Extensions
{
  public static class ServiceCollectionExtension
  {
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("TokenKey").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
          };
        });

      return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
      services.AddScoped<ITokenService, TokenService>();

      return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config)
    {
      services.AddDbContext<DatingAppContext>(options =>
      {
        options.UseSqlServer(config.GetConnectionString("DatingApp"));
      });

      return services;
    }
    
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
      services.AddTransient<IUnitOfWork, UnitOfWork>();
      
      return services;
    }
  }
}
