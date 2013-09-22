using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace ASPNETIdentity
{
  // Modify the User class to add extra user information
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

  public class IdentityDbContext : DbContext
  {
    public IdentityDbContext() : base("DefaultConnection") { }

    public IdentityDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

    // This method ensures that user names are always unique
    protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
    {
      if (entityEntry.State == EntityState.Added)
      {
        User user = entityEntry.Entity as User;
        // Check for uniqueness of user name
        if (user != null && Users.Where(u => u.UserName.ToUpper() == user.UserName.ToUpper()).Count() > 0)
        {
          var result = new DbEntityValidationResult(entityEntry, new List<DbValidationError>());
          result.ValidationErrors.Add(new DbValidationError("User", "User name must be unique."));
          return result;
        }
      }
      return base.ValidateEntity(entityEntry, items);
    }

    private DbSet<User> Users { get; set; }
  }
}