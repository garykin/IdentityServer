using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Volo.IdentityServer.Data.IdentityModels
{
    public class User : IdentityUser
        //<string, UserClaim, UserRole, UserLogin, UserToken>
        <string, UserClaim, UserRole, UserLogin>

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public User(string userName)
            : this()
        {
            UserName = userName;
        }

    }
}
