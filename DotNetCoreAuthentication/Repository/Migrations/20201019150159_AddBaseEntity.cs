using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreAuthentication.Repository.Migrations
{
    public partial class AddBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MailBoxes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MailBoxes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MailBoxes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MailBoxes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MailBoxes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MailBoxes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MailBoxes");

            migrationBuilder.InsertData(
                table: "MailBoxes",
                columns: new[] { "Id", "DateTime", "Message", "Receiver", "Sender", "Subject", "UserId" },
                values: new object[] { 1, new DateTime(2020, 10, 16, 14, 30, 17, 213, DateTimeKind.Local).AddTicks(69), "Test", "renato.alushi@gmail.com", "test@test.com", "Subjekti1", null });
        }
    }
}
