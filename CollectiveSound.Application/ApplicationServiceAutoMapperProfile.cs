using AutoMapper;
using CollectiveSound.Application.Permissions.Dto;
using CollectiveSound.Application.Roles.Dto;
using CollectiveSound.Application.Users.Dto;
using CollectiveSound.Core.Permissions;
using CollectiveSound.Core.Roles;
using CollectiveSound.Core.Users;

namespace CollectiveSound.Application
{
    public class ApplicationServiceAutoMapperProfile : Profile
    {
        public ApplicationServiceAutoMapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(u => u.Password, opt => opt.Ignore());

            CreateMap<User, UserListOutput>();
            CreateMap<Permission, PermissionDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<Role, RoleListOutput>();
        }
    }
}
