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
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Abilities> Abilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City() { Id = 1, CityName = "Ankara" },
                new City() { Id = 2, CityName = "İstanbul" }
            );

            modelBuilder.Entity<District>().HasData(
                new District() { Id = 1, CityId = 1, DistrictName = "Çankaya" },
                new District() { Id = 2, CityId = 1, DistrictName = "Keçiören" },
                new District() { Id = 3, CityId = 2, DistrictName = "Kadıköy" },
                new District() { Id = 4, CityId = 2, DistrictName = "Beyoğlu" }
            );
        }
    }
}
