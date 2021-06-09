using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class newAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "AdminId", 0, "b938d51d-4e7b-4607-b1a3-582afaa76dc7", "Administrator@email.com", true, false, null, "ADMINISTRATOR@EMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEHe/j60wbDMjBbl1+kGd4l8xams72tDii8BOIdKIZUBAtagv6Y5iu8zjAzgkpP2zgg==", null, false, "7c06b8d6-54f6-4ba4-b3b9-2bc604754c04", false, "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "AdminId", "3cc5e8d2-65ef-4d0c-98f9-83073142031b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "AdminId", "3cc5e8d2-65ef-4d0c-98f9-83073142031b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "AdminId");
        }
    }
}
