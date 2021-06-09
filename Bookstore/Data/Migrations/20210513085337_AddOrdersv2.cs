using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class AddOrdersv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Books_BookModelId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_BookModelId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BookModelId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "BookId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId1",
                table: "Order",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Books_BookId1",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_BookId1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "BookModelId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_BookModelId",
                table: "Order",
                column: "BookModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Books_BookModelId",
                table: "Order",
                column: "BookModelId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
