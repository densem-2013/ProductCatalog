using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalog.DAL.Migrations
{
    public partial class InitialDataStoreCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<int>(nullable: false),
                    Description = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecFields_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpecFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(nullable: false),
                    SpecFieldId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSpecFields_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSpecFields_SpecFieldId",
                        column: x => x.SpecFieldId,
                        principalTable: "SpecFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Manager" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, "Manager", "User", new byte[] { 15, 224, 85, 241, 126, 39, 247, 84, 253, 108, 11, 153, 238, 114, 188, 215, 172, 153, 96, 109, 36, 43, 236, 249, 10, 32, 216, 159, 111, 102, 70, 199, 103, 35, 152, 32, 236, 29, 132, 72, 131, 246, 207, 80, 237, 207, 166, 202, 79, 153, 8, 96, 78, 243, 158, 6, 167, 229, 78, 175, 250, 62, 103, 213 }, new byte[] { 164, 161, 184, 169, 95, 67, 12, 176, 27, 46, 247, 231, 107, 49, 95, 88, 248, 39, 20, 24, 147, 101, 141, 55, 7, 89, 225, 188, 185, 44, 128, 145, 247, 182, 70, 107, 207, 31, 174, 8, 170, 97, 74, 47, 215, 11, 152, 216, 96, 144, 54, 5, 116, 82, 235, 61, 52, 19, 12, 120, 65, 39, 3, 189, 168, 70, 70, 72, 74, 188, 254, 118, 225, 187, 40, 48, 199, 32, 27, 40, 162, 170, 103, 10, 103, 118, 68, 157, 9, 110, 164, 12, 39, 49, 188, 104, 61, 10, 161, 22, 203, 205, 230, 206, 69, 117, 7, 6, 201, 79, 99, 141, 110, 175, 234, 151, 131, 59, 116, 73, 121, 80, 146, 220, 215, 67, 61, 77 }, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecFields_ProductId",
                table: "ProductSpecFields",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecFields_SpecFieldId",
                table: "ProductSpecFields",
                column: "SpecFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecFields_CategoryId",
                table: "SpecFields",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSpecFields");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SpecFields");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
