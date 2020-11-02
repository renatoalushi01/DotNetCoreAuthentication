using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreAuthentication.Repository.Migrations
{
    public partial class AddBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "MailBoxes",
                "Id",
                1);

            migrationBuilder.AddColumn<DateTime>(
                "CreatedAt",
                "MailBoxes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                "IsDeleted",
                "MailBoxes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                "UpdatedAt",
                "MailBoxes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "CreatedAt",
                "MailBoxes");

            migrationBuilder.DropColumn(
                "IsDeleted",
                "MailBoxes");

            migrationBuilder.DropColumn(
                "UpdatedAt",
                "MailBoxes");

            migrationBuilder.InsertData(
                "MailBoxes",
                new[] {"Id", "DateTime", "Message", "Receiver", "Sender", "Subject", "UserId"},
                new object[]
                {
                    1, new DateTime(2020, 10, 16, 14, 30, 17, 213, DateTimeKind.Local).AddTicks(69), "Test",
                    "renato.alushi@gmail.com", "test@test.com", "Subjekti1", null
                });
        }
    }
}