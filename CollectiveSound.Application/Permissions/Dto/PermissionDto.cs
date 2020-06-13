using CollectiveSound.Application.Dto;

namespace CollectiveSound.Application.Permissions.Dto
{
    public class PermissionDto : EntityDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
}
