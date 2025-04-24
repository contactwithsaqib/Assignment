using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Model
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<CustomerInfo> CustomerInfo { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Gender data
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = "Male" },
                new Gender { Id = 2, Name = "Female" },
                new Gender { Id = 3, Name = "Other" }
            );

            // Seed State data
            modelBuilder.Entity<State>().HasData(
                new State { Id = 1, StateName = "Maharashtra" },
                new State { Id = 2, StateName = "Tamil Nadu" },
                new State { Id = 3, StateName = "Uttar Pradesh" }
            );

            // Seed District data
            modelBuilder.Entity<District>().HasData(
                new District { Id = 1, DistrictName = "Mumbai", StateId = 1 },
                new District { Id = 2, DistrictName = "Pune", StateId = 1 },
                new District { Id = 3, DistrictName = "Nagpur", StateId = 1 },
                new District { Id = 4, DistrictName = "Chennai", StateId = 2 },
                new District { Id = 5, DistrictName = "Madurai", StateId = 2 },
                new District { Id = 6, DistrictName = "Coimbatore", StateId = 2 },
                new District { Id = 7, DistrictName = "Lucknow", StateId = 3 },
                new District { Id = 8, DistrictName = "Kanpur", StateId = 3 },
                new District { Id = 9, DistrictName = "Agra", StateId = 3 }
            );
        }
    }
}