using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Volo.IdentityServer.Data.Stores
{
    public class ApplicationResourceStore : IResourceStore
    {
        public ApplicationResourceStore(IConfigurationDbContext context, IDbContextFactory<ConfigurationDbContext> factory)
        {
            var a = factory.Create(new DbContextFactoryOptions
            {
                EnvironmentName = "Dev"
            });
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "customAPI",
                    DisplayName = "Custom API",
                    Description = "Custom API Access",
                    UserClaims = new List<string> {"role"},
                    ApiSecrets = new List<Secret> {new Secret("scopeSecret".Sha256())},
                    Scopes = new List<Scope>
                    {
                        new Scope("customAPI.read"),
                        new Scope("customAPI.write")
                    }
                }
            };
        }



        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
              new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        #region IResourceStore
        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<Resources> GetAllResources()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
