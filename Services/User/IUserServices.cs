using FurryFriendsMVC.Models.User;

namespace FurryFriendsMVC.Services.User
{
    public interface IUserServices
    {
        Task<bool> CreateUserAsync(UserCreate model);
        Task<UserDetail> GetUserByIdAsync(int userId);
        Task<List<UserListItem>> GetAllUsersAsync();
        Task<bool> EditUsersAsync(UserEdit model);
        Task<bool> DeleteUser(int id);
    }
}