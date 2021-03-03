using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DatingApp.Application.Dtos;
using DatingApp.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.Infrastructure.Services
{
  public class TokenService : ITokenService
  {
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration config)
    {
      _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("TokenKey").Value));
    }

    public string CreateToken(UserDto userDto)
    {
      List<Claim> claims = new List<Claim>
      {
        new Claim(JwtRegisteredClaimNames.NameId, userDto.UserName)
      };

      SigningCredentials signingCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

      SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(2),
        SigningCredentials = signingCredentials
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }
  }
}