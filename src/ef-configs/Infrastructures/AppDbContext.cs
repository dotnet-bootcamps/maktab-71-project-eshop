using ef_configs.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ef_configs.Infrastructures
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\sql2019; Initial Catalog=DotNetShopDb_EfDataAnnotations; Integrated Security=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Title).HasMaxLength(500).IsRequired(false);
        }

        public DbSet<Product> Products { get; set; }
    }
}
