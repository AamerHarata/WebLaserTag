using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLaserTag.Migrations
{
    public partial class initailCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    HostName = table.Column<string>(nullable: true),
                    Password = table.Column<int>(nullable: false),
                    Ended = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    StartX = table.Column<double>(nullable: false),
                    StartY = table.Column<double>(nullable: false),
                    FlagX = table.Column<double>(nullable: false),
                    FlagY = table.Column<double>(nullable: false),
                    FlagHolder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    MacAddress = table.Column<string>(nullable: false),
                    GameId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => new { x.MacAddress, x.GameId });
                    table.ForeignKey(
                        name: "FK_Players_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayersData",
                columns: table => new
                {
                    PlayerMacAddress = table.Column<string>(nullable: false),
                    XGeo = table.Column<double>(nullable: false),
                    YGeo = table.Column<double>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    CurrentState = table.Column<int>(nullable: false),
                    HasFlag = table.Column<bool>(nullable: false),
                    PlayerMacAddress1 = table.Column<string>(nullable: true),
                    PlayerGameId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersData", x => x.PlayerMacAddress);
                    table.ForeignKey(
                        name: "FK_PlayersData_Players_PlayerMacAddress1_PlayerGameId",
                        columns: x => new { x.PlayerMacAddress1, x.PlayerGameId },
                        principalTable: "Players",
                        principalColumns: new[] { "MacAddress", "GameId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                table: "Players",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersData_PlayerMacAddress1_PlayerGameId",
                table: "PlayersData",
                columns: new[] { "PlayerMacAddress1", "PlayerGameId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersData");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
