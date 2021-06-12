using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class returnDatev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6d6ebb5-da95-49e6-80ce-d0eb1da19908", "AQAAAAEAACcQAAAAEASOb5kLTJjRKB7CaRhJbvIc+38cwCBZLxcLDp1FQS1xiPgvaQT/n0au8X/UgS5zEQ==", "4529b9bd-bba3-4425-9b4a-8e590b3e7269" });

            migrationBuilder.InsertData(
                table: "pickUpTimes",
                columns: new[] { "Id", "TimeToPickUpOrder" },
                values: new object[] { 2, 60 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "pickUpTimes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4af72e8e-ebbc-4a4b-bc63-110f07262358", "AQAAAAEAACcQAAAAEFhGj+STKQJ182tmuBy579waWvY1XDBkaOvJaRSAhkSbSxIPZ0jyFzh5BrolZXYM8w==", "0bfb25d8-9cba-481c-bbcf-544cedeb208d" });
        }
    }
}
