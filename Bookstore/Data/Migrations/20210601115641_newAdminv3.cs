using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class newAdminv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6a4034a-5f10-4830-b1ed-b8b9d77d7260", "AQAAAAEAACcQAAAAEIpnhEZwUCV2KTQYca/tjml/WRwYPi/HvahFDQwid3ws0HvRz4eSj13+J7sjhPitdw==", "879cb4aa-3141-4683-aba7-0d2baaadf56c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28c83141-2949-47f5-99ad-7298f246c881", "AQAAAAEAACcQAAAAENJvvg7db/7qM+YtbwdfPfjeGQFjnNfjcyPI0K6zSG1fxfk1IwhQLglhuHHxb6tORA==", "1bb8bf15-8441-4a66-bfbb-b5c43f29e0ab" });
        }
    }
}
