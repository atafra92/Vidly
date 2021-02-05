using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly_MVCApp.Data.Migrations
{
    public partial class AddApplicationUserReferenceToEFCore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DrivingLicence",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrivingLicence",
                table: "AspNetUsers");
        }
    }
}
