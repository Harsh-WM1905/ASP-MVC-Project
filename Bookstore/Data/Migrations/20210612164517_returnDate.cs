using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class returnDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4af72e8e-ebbc-4a4b-bc63-110f07262358", "AQAAAAEAACcQAAAAEFhGj+STKQJ182tmuBy579waWvY1XDBkaOvJaRSAhkSbSxIPZ0jyFzh5BrolZXYM8w==", "0bfb25d8-9cba-481c-bbcf-544cedeb208d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32451f76-6100-4974-9fc3-8eb0b1e94467", "AQAAAAEAACcQAAAAEIiVWu0PFtDPBK/CM1ZFXbpUEKlPaqgf/BZC+cMqfkU5IaQGj9MquOXw4oh/12cppw==", "2e1e2cea-14fa-4dd2-a4a1-80b438582493" });
        }
    }
}
