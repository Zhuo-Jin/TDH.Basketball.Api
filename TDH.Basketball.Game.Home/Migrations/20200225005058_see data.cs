using Microsoft.EntityFrameworkCore.Migrations;

namespace TDH.Basketball.Game.Home.Migrations
{
    public partial class seedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Mobile", "NickName", "Password" },
                values: new object[] { 1, "jinzhuo1783@gmail.com", "Zhuo", true, true, "Jin", "0413100244", "幫主", "1" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Mobile", "NickName", "Password" },
                values: new object[] { 2, "xxxx@gmail.com", "Hai", true, true, "SU", "0423233456", "書海", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
