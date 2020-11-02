using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreAuthentication.Repository.Migrations
{
    public partial class MailSender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "Name",
                "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                "LoginProvider",
                "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                "ProviderKey",
                "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                "LoginProvider",
                "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                "MailBoxes",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender = table.Column<string>(nullable: true),
                    Receiver = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_MailBoxes", x => x.Id); });

            migrationBuilder.InsertData(
                "MailBoxes",
                new[] {"Id", "DateTime", "Message", "Receiver", "Sender", "Subject"},
                new object[]
                {
                    1, new DateTime(2020, 10, 16, 11, 57, 41, 849, DateTimeKind.Local).AddTicks(6934), "Test",
                    "renato.alushi@gmail.com", "test@test.com", "Subjekti1"
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "MailBoxes");

            migrationBuilder.AlterColumn<string>(
                "Name",
                "AspNetUserTokens",
                "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                "LoginProvider",
                "AspNetUserTokens",
                "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                "ProviderKey",
                "AspNetUserLogins",
                "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                "LoginProvider",
                "AspNetUserLogins",
                "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}