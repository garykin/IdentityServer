using IdentityServer4.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Volo.IdentityServer.Data.IdentityModels;
using Volo.IdentityServer.Data.Stores;

namespace Volo.IdentityServer.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterEntityFramework(this IServiceCollection services, string connectionString)
        {
            // ASP.NET Identity DbContext
            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(connectionString));
            //   services.AddDbContext<Data.Identity.IdentityDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void RegisterIdentity(this IServiceCollection services)
        {
          //  var migrationsAssembly = typeof(ApplicationIdentityDbContext).GetTypeInfo().Assembly.GetName().Name;

            // ASP.NET Identity Registrations            
            services
                .AddIdentity<User, Role>()

                .AddUserStore<ApplicationUserStore>()
                .AddUserManager<ApplicationUserManager>()
                .AddRoleStore<ApplicationRoleStore>()
                .AddRoleManager<ApplicationRoleManager>()
                .AddSignInManager<ApplicationSignInManager>()
                // You **cannot** use .AddEntityFrameworkStores() when you customize everything
                // .AddEntityFrameworkStores<ApplicationIdentityDbContext>()

                .AddDefaultTokenProviders();



            services.AddScoped<IUserClaimsPrincipalFactory<User>, ClaimsPrincipalFactory>();
        }

        public static void RegisterIdentityServer(this IServiceCollection services, string connectionString)
        {
            var migrationsAssembly = typeof(ApplicationIdentityDbContext).GetTypeInfo().Assembly.GetName().Name;
            services.AddSingleton<IClientStore, ApplicationClientStore>();

            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryApiResources(ApplicationResourceStore.GetApiResources())
                .AddInMemoryIdentityResources(ApplicationResourceStore.GetIdentityResources())


             .AddOperationalStore(
                 builder => builder.UseSqlServer(Constants.DevConnectionString, options => options.MigrationsAssembly(migrationsAssembly)))
             .AddConfigurationStore(
                 builder => builder.UseSqlServer(Constants.DevConnectionString, options => options.MigrationsAssembly(migrationsAssembly)))
             .AddAspNetIdentity<User>()
             //.AddTemporarySigningCredential()
             ;


        }

        public static void RegisterSecurityServices(this IServiceCollection services, string connectionString)
        {
            RegisterEntityFramework(services, connectionString);
            RegisterIdentity(services);
            RegisterIdentityServer(services, connectionString);
        }
    }
}
