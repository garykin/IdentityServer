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
    public class PersistedGrantDbContextFactory : IDbContextFactory<PersistedGrantDbContext>
    {
        public PersistedGrantDbContext Create(DbContextFactoryOptions options)
        {
            var migrationsAssembly = typeof(ApplicationIdentityDbContext).GetTypeInfo().Assembly.GetName().Name;
            //var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;
            var builder = new DbContextOptionsBuilder<PersistedGrantDbContext>();
            builder.UseSqlServer(Constants.DevConnectionString, mo => mo.MigrationsAssembly(migrationsAssembly));
            return new PersistedGrantDbContext(builder.Options, new OperationalStoreOptions { DefaultSchema = "oper" });
        }
    }
}
