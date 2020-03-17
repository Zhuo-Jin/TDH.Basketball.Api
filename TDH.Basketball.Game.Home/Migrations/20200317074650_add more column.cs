using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TDH.Basketball.Game.Home.Migrations
{
    public partial class addmorecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPermanent",
                table: "Players",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaidDateTime",
                table: "Attendees",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPermanent",
                table: "Players");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaidDateTime",
                table: "Attendees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
