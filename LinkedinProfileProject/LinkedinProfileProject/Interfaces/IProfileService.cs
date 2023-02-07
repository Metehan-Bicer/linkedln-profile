using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Interfaces
{
    public interface IProfileService
    {
        Task<UserModel> GetUser();
    }
}
