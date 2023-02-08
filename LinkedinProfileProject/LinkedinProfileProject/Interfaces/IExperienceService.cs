using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Interfaces
{
    public interface IExperienceService
    {
        Task<List<ExperienceModel>> GetExperienceList(int userId);
        // Task<UserModel> SaveUpdateUser(UserModel userModel);
    }
}
