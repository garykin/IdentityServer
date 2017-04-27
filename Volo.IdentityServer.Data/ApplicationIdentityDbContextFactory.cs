using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Volo.IdentityServer.Data
{
    public class ApplicationIdentityDbContextFactory : IDbContextFactory<ApplicationIdentityDbContext>
    {
        public ApplicationIdentityDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<ApplicationIdentityDbContext>();
            builder.UseSqlServer(Constants.DevConnectionString);
            return new ApplicationIdentityDbContext(builder.Options);
        }
    }
}
