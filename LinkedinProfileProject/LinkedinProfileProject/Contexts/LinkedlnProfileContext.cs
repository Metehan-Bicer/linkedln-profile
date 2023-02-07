using LinkedinProfileProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkedinProfileProject.Contexts
{
    public class LinkedlnProfileContext : DbContext
    {
        public LinkedlnProfileContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<User> User { get; set; }

    }
}
