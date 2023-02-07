﻿using LinkedinProfileProject.Interfaces;
using LinkedinProfileProject.Mappers;
using LinkedinProfileProject.Services;
using Microsoft.EntityFrameworkCore;

namespace LinkedinProfileProject.Contexts
{
    public static class LinkedlnProfileExtention
    {
        public static void ConfigureLinkedlnServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LinkedlnProfileContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LinkedlnProfileContext")));

            //todo mete scope lar eklenecek
            services.AddScoped<IProfileService, ProfileService>();


            services.AddAutoMapper(
           typeof(UserMapper)
           );
        }
    }
}