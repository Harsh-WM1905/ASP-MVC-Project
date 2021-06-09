using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class newAdminv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "AdminId", "3cc5e8d2-65ef-4d0c-98f9-83073142031b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "AdminId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "69kjc8ab-d412-4a76-bb7d-e971d2d48c46", 0, "28c83141-2949-47f5-99ad-7298f246c881", "Administrator@email.com", true, false, null, null, null, "AQAAAAEAACcQAAAAENJvvg7db/7qM+YtbwdfPfjeGQFjnNfjcyPI0K6zSG1fxfk1IwhQLglhuHHxb6tORA==", null, false, "1bb8bf15-8441-4a66-bfbb-b5c43f29e0ab", false, "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "69kjc8ab-d412-4a76-bb7d-e971d2d48c46", "3cc5e8d2-65ef-4d0c-98f9-83073142031b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "69kjc8ab-d412-4a76-bb7d-e971d2d48c46", "3cc5e8d2-65ef-4d0c-98f9-83073142031b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "AdminId", 0, "b938d51d-4e7b-4607-b1a3-582afaa76dc7", "Administrator@email.com", true, false, null, "ADMINISTRATOR@EMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEHe/j60wbDMjBbl1+kGd4l8xams72tDii8BOIdKIZUBAtagv6Y5iu8zjAzgkpP2zgg==", null, false, "7c06b8d6-54f6-4ba4-b3b9-2bc604754c04", false, "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "AdminId", "3cc5e8d2-65ef-4d0c-98f9-83073142031b" });
        }
    }
}
