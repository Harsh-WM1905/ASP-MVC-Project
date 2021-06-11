using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class PickUpTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pickUpTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeToPickUpOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pickUpTimes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32451f76-6100-4974-9fc3-8eb0b1e94467", "AQAAAAEAACcQAAAAEIiVWu0PFtDPBK/CM1ZFXbpUEKlPaqgf/BZC+cMqfkU5IaQGj9MquOXw4oh/12cppw==", "2e1e2cea-14fa-4dd2-a4a1-80b438582493" });

            migrationBuilder.InsertData(
                table: "pickUpTimes",
                columns: new[] { "Id", "TimeToPickUpOrder" },
                values: new object[] { 1, 20 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pickUpTimes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e797f08-6051-40e6-8178-22698c624524", "AQAAAAEAACcQAAAAEGMdGWd8gFSBACCCVamc+g50N1tl8/6ZfzduVTSbuwsWd4rFNai9A/pL6jSxAJBOUA==", "a05ff61d-63df-4c9a-b80a-d9c3de93a553" });
        }
    }
}
