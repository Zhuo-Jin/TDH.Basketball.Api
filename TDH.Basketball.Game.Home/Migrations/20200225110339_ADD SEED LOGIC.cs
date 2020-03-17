using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TDH.Basketball.Game.Home.Migrations
{
    public partial class ADDSEEDLOGIC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "CourtRentFees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "BasketballCentres",
                nullable: true);

            migrationBuilder.InsertData(
                table: "BasketballCentres",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "ImageName", "Name", "Postcode", "State", "Suburb" },
                values: new object[,]
                {
                    { 1, "724 Victoria Rd", "", "1.jpg", "ryde russ basketball club", "2112", "NSW", "Ryde" },
                    { 2, "Church St", "", "2.jpg", "Auburn Basketball Centre", "2141", "NSW", "Lidcombe" }
                });

            migrationBuilder.InsertData(
                table: "CourtTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Full" },
                    { 2, "Half" }
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "NickName",
                value: "蘇海");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BasketballCentres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BasketballCentres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourtTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourtTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "CourtRentFees");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "BasketballCentres");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "NickName",
                value: "書海");
        }
    }
}
