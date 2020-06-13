using CollectiveSound.Application.Dto;

namespace CollectiveSound.Application.Roles.Dto
{
    public class RoleListOutput : PagedListOutput
    {
        public string Name { get; set; }

        public bool IsSystemDefault { get; set; }
    }
}
