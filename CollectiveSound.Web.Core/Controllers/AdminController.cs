using CollectiveSound.Core.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace CollectiveSound.Web.Core.Controllers
{
    [Authorize(Policy = DefaultPermissions.PermissionNameForAdministration)]
    public class AdminController : BaseController
    {

    }
}
