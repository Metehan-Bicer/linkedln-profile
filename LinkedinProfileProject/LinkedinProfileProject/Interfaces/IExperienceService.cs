using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Interfaces
{
    public interface IExperienceService
    {
        Task<List<ExperienceModel>> GetExperienceList(int userId);
        Task<ExperienceModel> GetExperienceById(int expId);
        Task<ExperienceModel> SaveUpdateExperience(ExperienceModel experienceModel);
        Task<bool> DeleteExperience(int id);
    }
}
