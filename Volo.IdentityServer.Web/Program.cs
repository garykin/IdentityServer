using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.IO;
using System.Linq;
using Volo.IdentityServer.Data;
using Volo.IdentityServer.Data.Stores;

namespace Volo.IdentityServer.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            SeedIdentityServerConfigurationDb();

            host.Run();
        }


        private static void SeedIdentityServerConfigurationDb()
        {
            var factory = new ConfigurationDbContextFactory();
            var context = factory.Create(new DbContextFactoryOptions
            {
                EnvironmentName = "Dev"
            });

            if (!context.Clients.Any())
            {
                foreach (var client in ApplicationClientStore.Clients)
                    context.Clients.Add(client.ToEntity());
                context.SaveChanges();
            }




            if (!context.IdentityResources.Any())
            {
                foreach (var resource in ApplicationResourceStore.GetIdentityResources())
                    context.IdentityResources.Add(resource.ToEntity());
                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in ApplicationResourceStore.GetApiResources())
                    context.ApiResources.Add(resource.ToEntity());
                context.SaveChanges();
            }
        }
    }
}
