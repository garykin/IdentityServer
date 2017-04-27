using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.IdentityServer.Data.IdentityModels;

namespace Volo.IdentityServer.Data
{
    public class ApplicationIdentityDbContext : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, IdentityRoleClaim<string>, UserToken>
    //IdentityDbContext<User, UserRole, string, UserClaim, UserRole, UserLogin, IdentityRoleClaim<string>, UserToken>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().ForSqlServerToTable("Roles", "dbo");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ForSqlServerToTable("RoleClaims", "dbo");
            modelBuilder.Entity<User>().ForSqlServerToTable("Users", "dbo");
            modelBuilder.Entity<UserClaim>().ForSqlServerToTable("UserClaims", "dbo");
            modelBuilder.Entity<UserLogin>().ForSqlServerToTable("UserLogins", "dbo");
            modelBuilder.Entity<UserRole>().ForSqlServerToTable("UserRoles", "dbo");
            modelBuilder.Entity<UserToken>().ForSqlServerToTable("UserTokens", "dbo");
        }
    }
}
