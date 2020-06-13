using CollectiveSound.Application.Dto;

namespace CollectiveSound.Application.Users.Dto
{
    public class UserListInput : PagedListInput
    {
        public UserListInput()
        {
            SortBy = "UserName";
        }
    }
}
