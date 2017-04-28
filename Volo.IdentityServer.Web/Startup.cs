using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Volo.IdentityServer.Data;
using Volo.IdentityServer.Data.IdentityModels;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.DbContexts;

using System.Linq;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Volo.IdentityServer.Data.TestConfiguration;
using Volo.IdentityServer.Data.Extensions;

using Microsoft.AspNetCore.Http;

namespace Volo.IdentityServer.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //const string connectionString = Constants.DevConnectionString;
            ////  @"Data Source=UADP16WS\SQLEXPRESS;database=VoloIdentityServer;trusted_connection=yes;";

            //var migrationsAssembly = typeof(ApplicationIdentityDbContext).GetTypeInfo().Assembly.GetName().Name;

            //// ASP.NET Identity DbContext
            //services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(connectionString));

            //// ASP.NET Identity Registrations            
            //services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApplicationIdentityDbContext>();

            //services.AddIdentityServer()
            //    .AddOperationalStore(
            //        builder => builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationsAssembly)))
            //    .AddConfigurationStore(
            //        builder => builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationsAssembly)))
            //    .AddAspNetIdentity<User>()
            //    .AddTemporarySigningCredential();

            //// services.AddMvc();



            services.RegisterSecurityServices(Constants.DevConnectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            //  if (env.IsDevelopment())
            //  {
            app.UseDeveloperExceptionPage();
            //  }


            // InitializeDbTestData(app);

            app.UseIdentity();
            app.UseIdentityServer();

            // app.UseStaticFiles();
            // app.UseMvcWithDefaultRoute();

            app.Run(async context => { await context.Response.WriteAsync("Panda`s Identity Server!"); });
        }

        //private static void InitializeDbTestData(IApplicationBuilder app)
        //{
        //    using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        //    {
        //        scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
        //        scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.Migrate();
        //        scope.ServiceProvider.GetRequiredService<ApplicationIdentityDbContext>().Database.Migrate();

        //        var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

        //        if (!context.Clients.Any())
        //        {
        //            foreach (var client in Clients.Get())
        //            {
        //                context.Clients.Add(client.ToEntity());
        //            }
        //            context.SaveChanges();
        //        }

        //        if (!context.IdentityResources.Any())
        //        {
        //            foreach (var resource in Resources.GetIdentityResources())
        //            {
        //                context.IdentityResources.Add(resource.ToEntity());
        //            }
        //            context.SaveChanges();
        //        }

        //        if (!context.ApiResources.Any())
        //        {
        //            foreach (var resource in Resources.GetApiResources())
        //            {
        //                context.ApiResources.Add(resource.ToEntity());
        //            }
        //            context.SaveChanges();
        //        }

        //        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        //        if (!userManager.Users.Any())
        //        {
        //            foreach (var testUser in Users.Get())
        //            {
        //                var identityUser = new User(testUser.Username)
        //                {
        //                    Id = testUser.SubjectId
        //                };

        //                foreach (var claim in testUser.Claims)
        //                {
        //                    identityUser.Claims.Add(new UserClaim
        //                    {
        //                        UserId = identityUser.Id,
        //                        ClaimType = claim.Type,
        //                        ClaimValue = claim.Value,
        //                    });
        //                }

        //                userManager.CreateAsync(identityUser, "Password123!").Wait();
        //            }
        //        }
        //    }
        //}
    }
}
