using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class miragtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b59ad861-b614-42ad-b4a0-2c1fa2f28966", "AQAAAAEAACcQAAAAEARq2AlRlq6j3vHaq4cd4T3wcKr0NMnukim4YxbkMiSip9zSfKLEpVuZKVd5xxda7A==", "9162a2fa-16b7-4dd6-b7ff-44fd21d5fc87" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a395e63f-c38b-4f2f-9d71-81767d4a9044", "AQAAAAEAACcQAAAAEMBm2EhAIhzNpFd5oYhChEKPKLKT8o4fp+7BBc7za+uKE8FYlZ4A1ctJnfAXucHpgw==", "d26b01b1-3bdf-4213-bcbd-39f279cf26b7" });
        }
    }
}
