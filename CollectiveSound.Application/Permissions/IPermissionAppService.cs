using CollectiveSound.Application.Permissions.Dto;
using CollectiveSound.Core.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollectiveSound.Application.Permissions
{
    public interface IPermissionAppService
    {
        Task<IEnumerable<PermissionDto>> GetGrantedPermissionsAsync(string userNameOrEmail);

        Task<bool> IsUserGrantedToPermissionAsync(string userNameOrEmail, string permissionName);

        void InitializePermissions(List<Permission> permissions);
    }
}
