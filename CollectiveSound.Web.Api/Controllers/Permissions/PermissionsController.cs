using CollectiveSound.Application.Permissions;
using CollectiveSound.Application.Permissions.Dto;
using CollectiveSound.Web.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollectiveSound.Web.Api.Controllers.Permissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : AuthorizedController
    {
        private readonly IPermissionAppService _permissionAppService;

        public PermissionsController(IPermissionAppService permissionAppService)
        {
            _permissionAppService = permissionAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> GetPermissions(string userNameOrEmail)
        {
            return Ok(await _permissionAppService.GetGrantedPermissionsAsync(userNameOrEmail));
        }
    }
}
