using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreAuthentication.Repository.Migrations
{
    public partial class UserINFO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "LastName",
                "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "LastName",
                "AspNetUsers");
        }
    }
}