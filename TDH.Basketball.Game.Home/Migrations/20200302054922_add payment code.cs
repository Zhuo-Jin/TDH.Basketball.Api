using Microsoft.EntityFrameworkCore.Migrations;

namespace TDH.Basketball.Game.Home.Migrations
{
    public partial class addpaymentcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CentreId",
                table: "Terms");

            migrationBuilder.AddColumn<string>(
                name: "PaymentCode",
                table: "Attendees",
                type: "varchar(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentCode",
                table: "Attendees");

            migrationBuilder.AddColumn<int>(
                name: "CentreId",
                table: "Terms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
