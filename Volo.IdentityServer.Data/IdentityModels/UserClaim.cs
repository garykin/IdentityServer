using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Volo.IdentityServer.Data.IdentityModels
{
    public class UserClaim : IdentityUserClaim<string>//, IBaseEntity<int>
    {
        public UserClaim()
        {

        }
    }
}
