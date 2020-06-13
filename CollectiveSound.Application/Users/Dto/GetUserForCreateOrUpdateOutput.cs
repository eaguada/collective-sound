using CollectiveSound.Application.Roles.Dto;
using System;
using System.Collections.Generic;

namespace CollectiveSound.Application.Users.Dto
{
    public class GetUserForCreateOrUpdateOutput
    {
        public UserDto User { get; set; } = new UserDto();

        public List<RoleDto> AllRoles { get; set; } = new List<RoleDto>();

        public List<Guid> GrantedRoleIds { get; set; } = new List<Guid>();
    }
}
