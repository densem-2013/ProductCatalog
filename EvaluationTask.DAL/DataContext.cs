using EvaluationTask.DAL.Entities;
using EvaluationTask.DAL.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EvaluationTask.DAL
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"), x =>
            {
                x.MigrationsAssembly("EvaluationTask.DAL");
                x.MigrationsHistoryTable("__EFMigrationsHistory", "dbo");
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SpecField> SpecFields { get; set; }
        public DbSet<ProductSpecField> ProductSpecFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(1, 1);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(1, 1);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(1, 1);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(1, 1);
            });

            modelBuilder.Entity<SpecField>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(1, 1);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId });

                entity.HasOne(d => d.Role)
                          .WithMany(p => p.UserRoles)
                          .HasForeignKey(d => d.RoleId)
                          .HasConstraintName("FK_UserRoles_RoleId");

                entity.HasOne(d => d.User)
                          .WithMany(p => p.UserRoles)
                          .HasForeignKey(d => d.UserId)
                          .HasConstraintName("FK_UserRoles_UserId");

            });

            modelBuilder.Entity<ProductSpecField>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.SpecFieldId });

                entity.HasOne(d => d.Product)
                          .WithMany(p => p.ProductSpecFields)
                          .HasForeignKey(d => d.ProductId)
                          .HasConstraintName("FK_ProductSpecFields_ProductId");

                entity.HasOne(d => d.SpecField)
                          .WithMany(p => p.ProductSpecFields)
                          .HasForeignKey(d => d.SpecFieldId)
                          .HasConstraintName("FK_ProductSpecFields_SpecFieldId");

            });

            modelBuilder.Entity<SpecField>(entity =>
            {
                entity.HasOne(d => d.Category)
                          .WithMany(p => p.SpecFields)
                          .HasForeignKey(d => d.CategoryId)
                          .HasConstraintName("FK_SpecFields_CategoryId");

            });

            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Manager" });

            byte[] passwordHash, passwordSalt;

            AppHelper.CreatePasswordHash("admin", out passwordHash, out passwordSalt);

            var user = new User { Id = 1, Username = "admin", FirstName = "Manager", LastName = "User", PasswordHash = passwordHash, PasswordSalt = passwordSalt };

            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<UserRole>().HasData(new UserRole { UserId = 1, RoleId = 1 });

        }
    }
}
