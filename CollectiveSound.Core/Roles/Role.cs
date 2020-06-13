using CollectiveSound.Core.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CollectiveSound.Core.Roles
{
    public class Role : IdentityRole<Guid>
    {
        public bool IsSystemDefault { get; set; } = false;

        public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
