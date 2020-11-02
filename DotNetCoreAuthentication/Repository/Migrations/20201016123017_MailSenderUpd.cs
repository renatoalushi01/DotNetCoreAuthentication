using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreAuthentication.Repository.Migrations
{
    public partial class MailSenderUpd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "UserId",
                "MailBoxes",
                nullable: true);

            migrationBuilder.UpdateData(
                "MailBoxes",
                "Id",
                1,
                "DateTime",
                new DateTime(2020, 10, 16, 14, 30, 17, 213, DateTimeKind.Local).AddTicks(69));

            migrationBuilder.CreateIndex(
                "IX_MailBoxes_UserId",
                "MailBoxes",
                "UserId");

            migrationBuilder.AddForeignKey(
                "FK_MailBoxes_AspNetUsers_UserId",
                "MailBoxes",
                "UserId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_MailBoxes_AspNetUsers_UserId",
                "MailBoxes");

            migrationBuilder.DropIndex(
                "IX_MailBoxes_UserId",
                "MailBoxes");

            migrationBuilder.DropColumn(
                "UserId",
                "MailBoxes");

            migrationBuilder.UpdateData(
                "MailBoxes",
                "Id",
                1,
                "DateTime",
                new DateTime(2020, 10, 16, 11, 57, 41, 849, DateTimeKind.Local).AddTicks(6934));
        }
    }
}