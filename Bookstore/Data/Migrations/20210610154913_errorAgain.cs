using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class errorAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a82d73e-59e2-457c-9c10-3a58329a698b", "AQAAAAEAACcQAAAAEKSkoH+5kJRGsDsp/Qs2Gr2Pe94Esh5o9r/6hopZvJLuX3gwT38NAMfFNof/cJoHQQ==", "d78a91c8-ea70-4932-af8e-0c8775133b15" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2090de0-3c4f-4702-92fd-4f7798a0e992", "AQAAAAEAACcQAAAAEMhAf36x+ZUOQpjbMJmeHGFZR2bchXBGMDqxdMf9M4miL6ZN2DzX+ivAk/NU0mlP7w==", "cf3dedaa-2d92-4108-a170-9f91e2e346db" });
        }
    }
}
