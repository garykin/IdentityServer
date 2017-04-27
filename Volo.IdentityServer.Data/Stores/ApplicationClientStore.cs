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
                ClientId = "PandaClient",
                ClientName = "Panda Web Api",
                AccessTokenLifetime = 60*60*24,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                RequireClientSecret = false,
                AllowedScopes = {"openid", "PandaApi", "PandaIdentity" }
            }
        };

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult(Clients.FirstOrDefault(c => c.ClientId == clientId));
        }
    }
}
