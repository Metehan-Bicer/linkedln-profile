﻿using LinkedinProfileProject.Interfaces;
using LinkedinProfileProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace LinkedinProfileProject.Controllers
{
    [Route("api/education")]
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            this._educationService = educationService;
        }
        [HttpGet("getEducationList/{userId}")]
        public async Task<List<EducationModel>> GetEducationList(int userId)
        {
            return await _educationService.GetEducationList(userId);
        }
        [HttpPost("saveUpdateEducation")]
        public async Task<EducationModel> SaveUpdateEducation([FromBody] EducationModel educationModel)
        {
            return await _educationService.SaveUpdateEducation(educationModel);
        }
        [HttpPost("deleteEducationByUserId")]
        public async Task<bool> DeleteEducationByUserId([FromBody] int id)
        {
            return await _educationService.DeleteEducation(id);
        }
    }
}
