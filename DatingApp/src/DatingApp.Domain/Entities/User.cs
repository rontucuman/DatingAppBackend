using System;

namespace DatingApp.Domain.Entities
{
  public class User: BaseEntity
  {
    public String UserName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
  }
}
