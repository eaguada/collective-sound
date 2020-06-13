using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CollectiveSound.Core.Users
{
    public class User : IdentityUser<Guid>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
