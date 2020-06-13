using CollectiveSound.Application.Permissions.Dto;
using System;
using System.Collections.Generic;

namespace CollectiveSound.Application.Roles.Dto
{
    public class GetRoleForCreateOrUpdateOutput
    {
        public RoleDto Role { get; set; } = new RoleDto();

        public List<PermissionDto> AllPermissions { get; set; } = new List<PermissionDto>();

        public List<Guid> GrantedPermissionIds { get; set; } = new List<Guid>();
    }
}
