using CollectiveSound.Core.Roles;
using Microsoft.AspNetCore.Identity;
using System;

namespace CollectiveSound.Core.Users
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
