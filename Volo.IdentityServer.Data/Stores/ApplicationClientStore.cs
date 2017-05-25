using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.IdentityServer.Data.Stores
{
    public class ApplicationClientStore : IClientStore
    {
        public static IEnumerable<Client> Clients { get; } = new[]
        {
            new Client
            {
                //AccessTokenType = AccessTokenType.Reference,
                ClientId = "PandaOpenIdConnectClient2",
                ClientName = "Example Implicit Client Application",
               // AccessTokenLifetime = 60*60*24,
                //AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedGrantTypes = GrantTypes.Implicit,
                RequireClientSecret = false,
                AllowedScopes = //{"openid", "PandaApi", "PandaIdentity" }
                new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "role",
                    "customAPI.write"
                },
                 RedirectUris = new List<string> { "https://localhost:44391/signin-oidc" },
                 PostLogoutRedirectUris = new List<string> { "https://localhost:44391" }
            }
        };

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult(Clients.FirstOrDefault(c => c.ClientId == clientId));
        }
    }
}
