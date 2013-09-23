using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace MonopolyWeb.Models.Core.Identity
{
  public class User : IUser
  {
    public User() : this(String.Empty) { }

    public User(string userName)
    {
      UserName = userName;
      Id = Guid.NewGuid().ToString();
    }

    [Key]
    public string Id { get; set; }

    public string UserName { get; set; }
  }
}