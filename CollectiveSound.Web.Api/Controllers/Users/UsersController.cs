using CollectiveSound.Application.Dto;
using CollectiveSound.Application.Users;
using CollectiveSound.Application.Users.Dto;
using CollectiveSound.Core.Permissions;
using CollectiveSound.Utils.Collections;
using CollectiveSound.Web.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CollectiveSound.Web.Api.Controllers.Users
{
    public class UsersController : AdminController
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        [Authorize(Policy = DefaultPermissions.PermissionNameForUserRead)]
        public async Task<ActionResult<IPagedList<UserListOutput>>> GetUsers([FromQuery] UserListInput input)
        {
            return Ok(await _userAppService.GetUsersAsync(input));
        }

        [HttpGet("{id}")]
        [Authorize(Policy = DefaultPermissions.PermissionNameForUserCreate)]
        [Authorize(Policy = DefaultPermissions.PermissionNameForUserUpdate)]
        public async Task<ActionResult<GetUserForCreateOrUpdateOutput>> GetUsers(Guid id)
        {
            var getUserForCreateOrUpdateOutput = await _userAppService.GetUserForCreateOrUpdateAsync(id);

            return Ok(getUserForCreateOrUpdateOutput);
        }

        [HttpPost]
        [Authorize(Policy = DefaultPermissions.PermissionNameForUserCreate)]
        public async Task<ActionResult> PostUsers([FromBody] CreateOrUpdateUserInput input)
        {
            var identityResult = await _userAppService.AddUserAsync(input);

            if (identityResult.Succeeded)
            {
                return Created(Url.Action("PostUsers"), identityResult);
            }

            return BadRequest(identityResult.Errors.Select(e => new NameValueDto(e.Code, e.Description)));
        }

        [HttpPut]
        [Authorize(Policy = DefaultPermissions.PermissionNameForUserCreate)]
        public async Task<ActionResult> PutUsers([FromBody] CreateOrUpdateUserInput input)
        {
            var identityResult = await _userAppService.EditUserAsync(input);

            if (identityResult.Succeeded)
            {
                return Ok();
            }

            return BadRequest(identityResult.Errors.Select(e => new NameValueDto(e.Code, e.Description)));
        }

        [HttpDelete]
        [Authorize(Policy = DefaultPermissions.PermissionNameForUserDelete)]
        public async Task<ActionResult> DeleteUsers(Guid id)
        {
            var identityResult = await _userAppService.RemoveUserAsync(id);

            if (identityResult.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(identityResult.Errors.Select(e => new NameValueDto(e.Code, e.Description)));
        }
    }
}
