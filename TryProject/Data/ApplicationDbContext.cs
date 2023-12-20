using Microsoft.EntityFrameworkCore;
using System.Data;
using TryProject.Model;

namespace TryProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> DataSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Hardik",
                    IsActive = true
                },
                new Category
                {
                    Id = 2,
                    Name = "Hd",
                    IsActive = true
                }
            );
        }

    }
}
