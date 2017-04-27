using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.IdentityServer.Data.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Volo.IdentityServer.Data.Stores
{
    public class ApplicationUserStore : UserStore<User, Role, ApplicationIdentityDbContext, string, UserClaim, UserRole, UserLogin, UserToken, IdentityRoleClaim<string>>
    {
        public ApplicationUserStore(ApplicationIdentityDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }

        protected override UserClaim CreateUserClaim(User user, Claim claim)
        {
            throw new NotImplementedException();
        }

        protected override UserLogin CreateUserLogin(User user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        protected override UserRole CreateUserRole(User user, Role role)
        {
            throw new NotImplementedException();
        }

        protected override UserToken CreateUserToken(User user, string loginProvider, string name, string value)
        {
            throw new NotImplementedException();
        }
    }
}
