using Microsoft.EntityFrameworkCore;
using SurvivorApi.Entities;

namespace SurvivorApi.Data
{
    public class SurvivorDbContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<CompetitorEntity> Competitors { get; set; }

        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompetitorEntity>()
                        .HasOne(x => x.Category)
                        .WithMany(x => x.Competitors)
                        .HasForeignKey(x => x.CategoryId);
        }

    }
}
