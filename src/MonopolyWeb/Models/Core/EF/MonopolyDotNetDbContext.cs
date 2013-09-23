﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace MonopolyWeb.Models.Core.EF
{
  public class MonopolyDotNetDbContext : DbContext
  {

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

    //property injected by EF, so, uh, don't make this private
    // ReSharper disable once MemberCanBePrivate.Global
    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }
  }
}