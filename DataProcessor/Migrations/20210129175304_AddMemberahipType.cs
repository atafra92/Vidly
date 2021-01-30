using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProcessor.Migrations
{
    public partial class AddMemberahipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembershipTypeId",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignUpFee = table.Column<decimal>(nullable: false),
                    DurationInMonths = table.Column<byte>(nullable: false),
                    DiscountRate = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_MembershipTypeId",
                table: "Customer",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_MembershipType_MembershipTypeId",
                table: "Customer",
                column: "MembershipTypeId",
                principalTable: "MembershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_MembershipType_MembershipTypeId",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropIndex(
                name: "IX_Customer_MembershipTypeId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "Customer");
        }
    }
}
