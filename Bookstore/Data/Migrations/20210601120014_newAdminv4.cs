using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class newAdminv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b7acccc1-4115-4596-9258-d0ad0bc3eb71", "ADMINISTRATOR@EMAIL.COM", "ADMINISTRATOR@EMAIL.COM", "AQAAAAEAACcQAAAAEBwBDH6G08YCD8n4wapycHDLcqgz9//Q+P01rgHKiKCBuAwkIO37mfXMKRqn8D0cLg==", "8ebc1d99-6d7f-4a04-8103-e4f0ee72fd87", "Administrator@email.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b6a4034a-5f10-4830-b1ed-b8b9d77d7260", null, null, "AQAAAAEAACcQAAAAEIpnhEZwUCV2KTQYca/tjml/WRwYPi/HvahFDQwid3ws0HvRz4eSj13+J7sjhPitdw==", "879cb4aa-3141-4683-aba7-0d2baaadf56c", "Administrator" });
        }
    }
}
