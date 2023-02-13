using LinkedinProfileProject.Interfaces;
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
            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IAbilitiesService, AbilitiesService>();
            services.AddScoped<ILogService, LogService>();


            services.AddAutoMapper(
           typeof(UserMapper),
           typeof(BaseMapper),
           typeof(ExperienceMapper),
           typeof(EducationMapper),
           typeof(AbilitiesMapper),
           typeof(FileUploadMapper)

           );
        }
    }
}
