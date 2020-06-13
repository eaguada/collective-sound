using CollectiveSound.Application.Dto;

namespace CollectiveSound.Application.Roles.Dto
{
    public class RoleListInput : PagedListInput
    {
        public RoleListInput()
        {
            SortBy = "Name";
        }
    }
}
