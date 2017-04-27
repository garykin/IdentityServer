using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Volo.IdentityServer.Data
{
    public class ConfigurationDbContextFactory : IDbContextFactory<ConfigurationDbContext>
    {
        public ConfigurationDbContext Create(DbContextFactoryOptions options)
        {
            var migrationsAssembly = typeof(ApplicationIdentityDbContext).GetTypeInfo().Assembly.GetName().Name;
            var builder = new DbContextOptionsBuilder<ConfigurationDbContext>();
            builder.UseSqlServer(Constants.DevConnectionString, mo => mo.MigrationsAssembly(migrationsAssembly));
            //builder.UseSqlServer(Constants.DevConnectionString);
            return new ConfigurationDbContext(builder.Options, new ConfigurationStoreOptions { DefaultSchema = "config" });
        }
    }
}
