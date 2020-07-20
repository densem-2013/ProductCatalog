using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductCatalog.DAL.Entities;
using ProductCatalog.DAL.Helpers;

namespace ProductCatalog.DAL
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
                x.MigrationsAssembly("ProductCatalog.DAL");
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
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }

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
                entity.Property(e => e.Id).UseIdentityColumn(1, 1);

                entity.HasOne(d => d.Product)
                          .WithMany(p => p.SpecificationData)
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
        }
    }
}
