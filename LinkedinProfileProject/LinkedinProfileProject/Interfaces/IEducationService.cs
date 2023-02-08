using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Interfaces
{
    public interface IEducationService
    {
        Task<List<EducationModel>> GetEducationList(int userId);
        // Task<UserModel> SaveUpdateUser(UserModel userModel);
    }
}
