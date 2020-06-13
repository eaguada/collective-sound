using CollectiveSound.Application.Users.Dto;
using CollectiveSound.Utils.Collections;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace CollectiveSound.Application.Users
{
    public interface IUserAppService
    {
        Task<IPagedList<UserListOutput>> GetUsersAsync(UserListInput input);

        Task<GetUserForCreateOrUpdateOutput> GetUserForCreateOrUpdateAsync(Guid id);

        Task<IdentityResult> AddUserAsync(CreateOrUpdateUserInput input);

        Task<IdentityResult> EditUserAsync(CreateOrUpdateUserInput input);

        Task<IdentityResult> RemoveUserAsync(Guid id);
    }
}
