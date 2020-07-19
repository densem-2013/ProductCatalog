﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductCatalog.DAL;

namespace ProductCatalog.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200719221919_SoftDeletedFieldsAddedToDomainEntities")]
    partial class SoftDeletedFieldsAddedToDomainEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("ProductCatalog.DAL.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Description")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Name")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProductCatalog.DAL.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductCatalog.DAL.Entities.ProductSpecField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpecFieldId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SpecFieldId");

                    b.ToTable("ProductSpecFields");
                });

            modelBuilder.Entity("ProductCatalog.DAL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Manager"
                        });
                });

            modelBuilder.Entity("ProductCatalog.DAL.Entities.SpecField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SpecFields");
                });

            modelBuilder.Entity("ProductCatalog.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Manager",
                            LastName = "User",
                            PasswordHash = new byte[] { 197, 188, 73, 114, 186, 41, 130, 35, 127, 184, 196, 67, 122, 135, 186, 230, 167, 61, 124, 53, 168, 18, 228, 132, 34, 209, 232, 212, 27, 136, 124, 153, 10, 62, 177, 250, 255, 216, 7, 59, 28, 16, 121, 138, 182, 242, 40, 8, 97, 179, 208, 84, 41, 226, 51, 160, 243, 177, 47, 156, 170, 53, 171, 104 },
                            PasswordSalt = new byte[] { 126, 84, 126, 151, 178, 11, 201, 64, 199, 76, 9, 23, 175, 229, 158, 236, 124, 154, 184, 48, 110, 147, 215, 96, 174, 104, 38, 165, 79, 245, 116, 52, 204, 174, 118, 206, 156, 105, 143, 211, 38, 98, 160, 168, 195, 110, 91, 148, 73, 130, 78, 252, 68, 4, 34, 29, 203, 7, 214, 213, 215, 191, 174, 115, 244, 43, 81, 232, 66, 6, 89, 185, 144, 122, 244, 59, 86, 112, 125, 176, 104, 247, 189, 213, 118, 239, 50, 195, 193, 192, 216, 49, 182, 232, 57, 165, 208, 133, 61, 222, 143, 169, 237, 120, 177, 150, 111, 182, 82, 237, 180, 76, 209, 25, 187, 178, 124, 133, 193, 217, 110, 71, 12, 216, 36, 30, 108, 104 },
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("ProductCatalog.DAL.Entities.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ProductCatalog.DAL.Entities.ProductSpecField", b =>
                {
                    b.HasOne("ProductCatalog.DAL.Entities.Product", "Product")
                        .WithMany("SpecificationData")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductSpecFields_ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductCatalog.DAL.Entities.SpecField", "SpecField")
                        .WithMany("ProductSpecFields")
                        .HasForeignKey("SpecFieldId")
                        .HasConstraintName("FK_ProductSpecFields_SpecFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductCatalog.DAL.Entities.SpecField", b =>
                {
                    b.HasOne("ProductCatalog.DAL.Entities.Category", "Category")
                        .WithMany("SpecFields")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_SpecFields_CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductCatalog.DAL.Entities.UserRole", b =>
                {
                    b.HasOne("ProductCatalog.DAL.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserRoles_RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductCatalog.DAL.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserRoles_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
