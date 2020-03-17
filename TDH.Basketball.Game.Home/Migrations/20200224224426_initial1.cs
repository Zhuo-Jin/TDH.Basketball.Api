using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TDH.Basketball.Game.Home.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketballCentres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketballCentres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourtTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationBoards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationText = table.Column<string>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    ReleaseDateTime = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourtRentFees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CentreId = table.Column<int>(nullable: false),
                    CourtTypeId = table.Column<int>(nullable: false),
                    ChargeFee = table.Column<decimal>(nullable: false),
                    IsCurrent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtRentFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourtRentFees_BasketballCentres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "BasketballCentres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourtRentFees_CourtTypes_CourtTypeId",
                        column: x => x.CourtTypeId,
                        principalTable: "CourtTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InOrOut = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    MyProperty = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    TransactionFee = table.Column<decimal>(nullable: false),
                    balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CentreId = table.Column<int>(nullable: false),
                    CourtRentFeeId = table.Column<int>(nullable: false),
                    TermName = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terms_CourtRentFees_CourtRentFeeId",
                        column: x => x.CourtRentFeeId,
                        principalTable: "CourtRentFees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermId = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Terms_TermId",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: false),
                    IsPermanent = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    ReplacedPlayerId = table.Column<int>(nullable: false),
                    FeeShared = table.Column<decimal>(nullable: false),
                    PaidDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendees_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attendees_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attendees_Players_ReplacedPlayerId",
                        column: x => x.ReplacedPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_EventId",
                table: "Attendees",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_PlayerId",
                table: "Attendees",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_ReplacedPlayerId",
                table: "Attendees",
                column: "ReplacedPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourtRentFees_CentreId",
                table: "CourtRentFees",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_CourtRentFees_CourtTypeId",
                table: "CourtRentFees",
                column: "CourtTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TermId",
                table: "Events",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_CourtRentFeeId",
                table: "Terms",
                column: "CourtRentFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PlayerId",
                table: "Transactions",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "NotificationBoards");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "CourtRentFees");

            migrationBuilder.DropTable(
                name: "BasketballCentres");

            migrationBuilder.DropTable(
                name: "CourtTypes");
        }
    }
}
