using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class AddOrdersv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Books_BookId1",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_BookId1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_BookId",
                table: "Order",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Books_BookId",
                table: "Order",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Books_BookId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_BookId",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "BookId",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId1",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_BookId1",
                table: "Order",
                column: "BookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Books_BookId1",
                table: "Order",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
