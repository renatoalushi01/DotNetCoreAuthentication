using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreAuthentication.Repository.Migrations
{
    public partial class MailSenderUpd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MailBoxes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MailBoxes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2020, 10, 16, 14, 30, 17, 213, DateTimeKind.Local).AddTicks(69));

            migrationBuilder.CreateIndex(
                name: "IX_MailBoxes_UserId",
                table: "MailBoxes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MailBoxes_AspNetUsers_UserId",
                table: "MailBoxes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MailBoxes_AspNetUsers_UserId",
                table: "MailBoxes");

            migrationBuilder.DropIndex(
                name: "IX_MailBoxes_UserId",
                table: "MailBoxes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MailBoxes");

            migrationBuilder.UpdateData(
                table: "MailBoxes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2020, 10, 16, 11, 57, 41, 849, DateTimeKind.Local).AddTicks(6934));
        }
    }
}
