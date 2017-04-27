using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.IdentityServer.Data.IdentityModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Volo.IdentityServer.Data.Stores
{
    public class ApplicationRoleStore : RoleStore<Role, ApplicationIdentityDbContext, string, UserRole, IdentityRoleClaim<string>>
    {
        public ApplicationRoleStore(ApplicationIdentityDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }

        protected override IdentityRoleClaim<string> CreateRoleClaim(Role role, Claim claim)
        {
            throw new NotImplementedException();
        }
    }
}
