using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProcessor.Migrations
{
    public partial class PopulateMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MembershipType(SignUpFee, DurationInMonths,DiscountRate) VALUES (0.00, 0, 0)");
            migrationBuilder.Sql("INSERT INTO MembershipType(SignUpFee, DurationInMonths,DiscountRate) VALUES (30.00, 1, 10)");
            migrationBuilder.Sql("INSERT INTO MembershipType(SignUpFee, DurationInMonths,DiscountRate) VALUES (90.00, 3, 15)");
            migrationBuilder.Sql("INSERT INTO MembershipType(SignUpFee, DurationInMonths,DiscountRate) VALUES (300.00, 12, 20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
