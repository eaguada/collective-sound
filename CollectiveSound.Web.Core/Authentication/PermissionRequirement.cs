using CollectiveSound.Core.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace CollectiveSound.Web.Core.Authentication
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(Permission permission)
        {
            Permission = permission;
        }

        public Permission Permission { get; }
    }
}
