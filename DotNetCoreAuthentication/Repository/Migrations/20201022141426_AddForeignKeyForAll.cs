using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreAuthentication.Repository.Migrations
{
    public partial class AddForeignKeyForAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "ApplicationId",
                "MailBoxes",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_MailBoxes_ApplicationId",
                "MailBoxes",
                "ApplicationId");

            migrationBuilder.AddForeignKey(
                "FK_MailBoxes_AspNetUsers_ApplicationId",
                "MailBoxes",
                "ApplicationId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_MailBoxes_AspNetUsers_ApplicationId",
                "MailBoxes");

            migrationBuilder.DropIndex(
                "IX_MailBoxes_ApplicationId",
                "MailBoxes");

            migrationBuilder.DropColumn(
                "ApplicationId",
                "MailBoxes");
        }
    }
}