﻿using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Interfaces
{
    public interface IAbilitiesService
    {
        Task<List<AbilitiesModel>> GetAbilitiesList(int userId);
        // Task<UserModel> SaveUpdateUser(UserModel userModel);
    }
}
