using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalog.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
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
                    ProductId = table.Column<int>(nullable: false),
                    SpecFieldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecFields", x => new { x.ProductId, x.SpecFieldId });
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
                values: new object[] { 1, "Manager", "User", new byte[] { 195, 57, 76, 248, 151, 180, 223, 168, 9, 238, 107, 87, 0, 247, 101, 116, 250, 156, 216, 164, 177, 3, 183, 30, 175, 64, 154, 21, 199, 141, 10, 128, 137, 42, 249, 137, 165, 42, 244, 225, 46, 51, 12, 19, 112, 102, 103, 135, 176, 191, 184, 77, 22, 65, 123, 171, 182, 23, 192, 141, 203, 88, 76, 175 }, new byte[] { 30, 54, 173, 114, 75, 101, 188, 109, 70, 113, 0, 210, 179, 177, 196, 178, 46, 202, 242, 138, 239, 204, 29, 89, 96, 136, 196, 236, 131, 120, 69, 176, 3, 228, 223, 63, 110, 108, 26, 141, 141, 76, 159, 135, 116, 252, 251, 181, 106, 214, 163, 86, 107, 201, 16, 30, 177, 99, 121, 220, 87, 88, 74, 10, 103, 5, 195, 246, 184, 204, 127, 241, 197, 108, 236, 21, 155, 55, 194, 46, 21, 181, 107, 82, 171, 11, 195, 32, 244, 141, 113, 190, 76, 151, 206, 49, 253, 149, 216, 232, 34, 106, 23, 197, 188, 99, 226, 8, 64, 146, 30, 194, 158, 244, 151, 138, 236, 65, 100, 160, 66, 172, 137, 206, 96, 14, 116, 73 }, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

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
