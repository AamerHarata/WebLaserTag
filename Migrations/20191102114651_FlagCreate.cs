using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLaserTag.Migrations
{
    public partial class FlagCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Ended = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    StartX = table.Column<double>(nullable: false),
                    StartY = table.Column<double>(nullable: false),
                    FlagX = table.Column<double>(nullable: false),
                    FlagY = table.Column<double>(nullable: false),
                    FlagHolder = table.Column<string>(nullable: true),
                    HostId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Players_HostId",
                        column: x => x.HostId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayersData",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    XGeo = table.Column<double>(nullable: false),
                    YGeo = table.Column<double>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    CurrentState = table.Column<int>(nullable: false),
                    HasFlag = table.Column<bool>(nullable: false),
                    Azimuth = table.Column<int>(nullable: false),
                    AimingAgainst = table.Column<string>(nullable: true),
                    GivenSignal = table.Column<int>(nullable: false),
                    PlayerId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersData", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_PlayersData_Players_PlayerId1",
                        column: x => x.PlayerId1,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flag",
                columns: table => new
                {
                    GameId = table.Column<string>(nullable: false),
                    XGeo = table.Column<double>(nullable: false),
                    YGeo = table.Column<double>(nullable: false),
                    Free = table.Column<bool>(nullable: false),
                    holderId = table.Column<string>(nullable: true),
                    GameId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flag", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Flag_Games_GameId1",
                        column: x => x.GameId1,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayersInGame",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    GameId = table.Column<string>(nullable: false),
                    Host = table.Column<bool>(nullable: false),
                    JoinTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersInGame", x => new { x.PlayerId, x.GameId });
                    table.ForeignKey(
                        name: "FK_PlayersInGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersInGame_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flag_GameId1",
                table: "Flag",
                column: "GameId1");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HostId",
                table: "Games",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersData_PlayerId1",
                table: "PlayersData",
                column: "PlayerId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersInGame_GameId",
                table: "PlayersInGame",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flag");

            migrationBuilder.DropTable(
                name: "PlayersData");

            migrationBuilder.DropTable(
                name: "PlayersInGame");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
