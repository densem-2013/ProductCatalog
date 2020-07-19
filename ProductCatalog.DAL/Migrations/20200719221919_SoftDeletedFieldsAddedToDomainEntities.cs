using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalog.DAL.Migrations
{
    public partial class SoftDeletedFieldsAddedToDomainEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SpecFields",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Categories",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 197, 188, 73, 114, 186, 41, 130, 35, 127, 184, 196, 67, 122, 135, 186, 230, 167, 61, 124, 53, 168, 18, 228, 132, 34, 209, 232, 212, 27, 136, 124, 153, 10, 62, 177, 250, 255, 216, 7, 59, 28, 16, 121, 138, 182, 242, 40, 8, 97, 179, 208, 84, 41, 226, 51, 160, 243, 177, 47, 156, 170, 53, 171, 104 }, new byte[] { 126, 84, 126, 151, 178, 11, 201, 64, 199, 76, 9, 23, 175, 229, 158, 236, 124, 154, 184, 48, 110, 147, 215, 96, 174, 104, 38, 165, 79, 245, 116, 52, 204, 174, 118, 206, 156, 105, 143, 211, 38, 98, 160, 168, 195, 110, 91, 148, 73, 130, 78, 252, 68, 4, 34, 29, 203, 7, 214, 213, 215, 191, 174, 115, 244, 43, 81, 232, 66, 6, 89, 185, 144, 122, 244, 59, 86, 112, 125, 176, 104, 247, 189, 213, 118, 239, 50, 195, 193, 192, 216, 49, 182, 232, 57, 165, 208, 133, 61, 222, 143, 169, 237, 120, 177, 150, 111, 182, 82, 237, 180, 76, 209, 25, 187, 178, 124, 133, 193, 217, 110, 71, 12, 216, 36, 30, 108, 104 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SpecFields");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 15, 224, 85, 241, 126, 39, 247, 84, 253, 108, 11, 153, 238, 114, 188, 215, 172, 153, 96, 109, 36, 43, 236, 249, 10, 32, 216, 159, 111, 102, 70, 199, 103, 35, 152, 32, 236, 29, 132, 72, 131, 246, 207, 80, 237, 207, 166, 202, 79, 153, 8, 96, 78, 243, 158, 6, 167, 229, 78, 175, 250, 62, 103, 213 }, new byte[] { 164, 161, 184, 169, 95, 67, 12, 176, 27, 46, 247, 231, 107, 49, 95, 88, 248, 39, 20, 24, 147, 101, 141, 55, 7, 89, 225, 188, 185, 44, 128, 145, 247, 182, 70, 107, 207, 31, 174, 8, 170, 97, 74, 47, 215, 11, 152, 216, 96, 144, 54, 5, 116, 82, 235, 61, 52, 19, 12, 120, 65, 39, 3, 189, 168, 70, 70, 72, 74, 188, 254, 118, 225, 187, 40, 48, 199, 32, 27, 40, 162, 170, 103, 10, 103, 118, 68, 157, 9, 110, 164, 12, 39, 49, 188, 104, 61, 10, 161, 22, 203, 205, 230, 206, 69, 117, 7, 6, 201, 79, 99, 141, 110, 175, 234, 151, 131, 59, 116, 73, 121, 80, 146, 220, 215, 67, 61, 77 } });
        }
    }
}
