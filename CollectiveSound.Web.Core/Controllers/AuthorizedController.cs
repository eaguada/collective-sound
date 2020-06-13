using CollectiveSound.Core.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace CollectiveSound.Web.Core.Controllers
{
    [Authorize(Policy = DefaultPermissions.PermissionNameForMemberAccess)]
    public class AuthorizedController : BaseController
    {

    }
}
