using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.IdentityServer.Data;
using Volo.IdentityServer.Data.Extensions;

namespace Volo.IdentityServer.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterSecurityServices(Constants.DevConnectionString);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // InitializeDbTestData(app);

            app.UseIdentity();
            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

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
