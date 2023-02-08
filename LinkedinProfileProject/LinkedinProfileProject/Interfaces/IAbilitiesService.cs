using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Interfaces
{
    public interface IAbilitiesService
    {
        Task<List<AbilitiesModel>> GetAbilitiesList(int userId);
        Task<AbilitiesModel> SaveUpdateAbilities(AbilitiesModel abilitiesModel);
    }
}
