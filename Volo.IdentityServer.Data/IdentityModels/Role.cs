using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Volo.IdentityServer.Data.IdentityModels
{
    public class Role : IdentityRole<string, UserRole, IdentityRoleClaim<string>>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole"/>.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public Role()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole"/>.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public Role(string roleName) : this()
        {
            Name = roleName;
        }

        public string Description { get; set; }

    }
}
