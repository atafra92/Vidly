using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProcessor.Migrations
{
    public partial class AddNameColumnMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MembershipTypes",
                nullable: true);

            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Pay as You go' WHERE Id = 1");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MembershipTypes");
        }
    }
}
