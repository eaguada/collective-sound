using CollectiveSound.Application.Dto;

namespace CollectiveSound.Application.Users.Dto
{
    public class UserListOutput : PagedListOutput
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
