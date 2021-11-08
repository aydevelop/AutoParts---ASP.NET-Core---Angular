using Database.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _Model = Database.Model.Model;

namespace Database
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<_Model> Models { get; set; }
        public DbSet<Spare> Spares { get; set; }
        public DbSet<Provider> Providers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<Category>().HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<Brand>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<Brand>().HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<_Model>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<_Model>().HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<Spare>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<Spare>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<Spare>().Property(s => s.Price).IsRequired();
            modelBuilder.Entity<Spare>().Property(s => s.ImageUrl).IsRequired();
            modelBuilder.Entity<Spare>().Property(s => s.Description).IsRequired();
            modelBuilder.Entity<Spare>().Property(s => s.Url).IsRequired();

            modelBuilder.Entity<Spare>().Property(p => p.Price).HasColumnType("decimal(18,4)");
        }
    }
}
