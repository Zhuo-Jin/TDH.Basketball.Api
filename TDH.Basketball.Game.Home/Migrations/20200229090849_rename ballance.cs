using Microsoft.EntityFrameworkCore.Migrations;

namespace TDH.Basketball.Game.Home.Migrations
{
    public partial class renameballance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "Transactions",
                newName: "Balance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Transactions",
                newName: "balance");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
