using CollectiveSound.Application.Roles.Dto;
using CollectiveSound.Utils.Collections;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace CollectiveSound.Application.Roles
{
    public interface IRoleAppService
    {
        Task<IPagedList<RoleListOutput>> GetRolesAsync(RoleListInput input);

        Task<GetRoleForCreateOrUpdateOutput> GetRoleForCreateOrUpdateAsync(Guid id);

        Task<IdentityResult> AddRoleAsync(CreateOrUpdateRoleInput input);

        Task<IdentityResult> EditRoleAsync(CreateOrUpdateRoleInput input);

        Task<IdentityResult> RemoveRoleAsync(Guid id);
    }
}
