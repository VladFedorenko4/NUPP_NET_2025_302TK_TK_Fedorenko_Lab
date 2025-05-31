using Microsoft.EntityFrameworkCore;
using Tourist.Infrastructure.Models;

namespace Tourist.Infrastructure
{
    public class TouristContext : DbContext
    {
        public DbSet<AgentModel> Agents { get; set; }

        public DbSet<BookingModel> Bookings { get; set; }

        public DbSet<TouristModel> Tourists { get; set; }

        public DbSet<PassportModel> Passports { get; set; }

        public DbSet<TourModel> Tours { get; set; }

        public DbSet<GuideModel> Guides { get; set; }

        public DbSet<TourPackageModel> TourPackages { get; set; }

        public TouristContext(DbContextOptions<TouristContext> options) : base(options) { }

        public TouristContext()
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-One
            modelBuilder.Entity<TouristModel>()
                .HasOne(t => t.Passport)
                .WithOne(p => p.Tourist)
                .HasForeignKey<TouristModel>(t => t.PassportId);

            // One-to-Many
            modelBuilder.Entity<TouristModel>()
                .HasMany(t => t.Tours)
                .WithMany(tour => tour.Tourists);

            // Table-per-Type (TPT) Inheritance
            modelBuilder.Entity<GuideModel>().ToTable("Guides");
            modelBuilder.Entity<TouristModel>().ToTable("Tourists");
        }
    }
}
