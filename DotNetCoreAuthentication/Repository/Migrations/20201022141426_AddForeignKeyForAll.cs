using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreAuthentication.Repository.Migrations
{
    public partial class AddForeignKeyForAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                table: "MailBoxes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MailBoxes_ApplicationId",
                table: "MailBoxes",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MailBoxes_AspNetUsers_ApplicationId",
                table: "MailBoxes",
                column: "ApplicationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MailBoxes_AspNetUsers_ApplicationId",
                table: "MailBoxes");

            migrationBuilder.DropIndex(
                name: "IX_MailBoxes_ApplicationId",
                table: "MailBoxes");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "MailBoxes");
        }
    }
}
