using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Interfaces
{
    public interface IProfileService
    {
        Task<UserModel> GetUser();
        Task<UserModel> GetUserById(int userId);
        Task<UserModel> SaveUpdateUser(UserModel userModel);
    }
}
