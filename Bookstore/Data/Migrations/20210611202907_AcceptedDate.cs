using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class AcceptedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptedDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e797f08-6051-40e6-8178-22698c624524", "AQAAAAEAACcQAAAAEGMdGWd8gFSBACCCVamc+g50N1tl8/6ZfzduVTSbuwsWd4rFNai9A/pL6jSxAJBOUA==", "a05ff61d-63df-4c9a-b80a-d9c3de93a553" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedDate",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a82d73e-59e2-457c-9c10-3a58329a698b", "AQAAAAEAACcQAAAAEKSkoH+5kJRGsDsp/Qs2Gr2Pe94Esh5o9r/6hopZvJLuX3gwT38NAMfFNof/cJoHQQ==", "d78a91c8-ea70-4932-af8e-0c8775133b15" });
        }
    }
}
