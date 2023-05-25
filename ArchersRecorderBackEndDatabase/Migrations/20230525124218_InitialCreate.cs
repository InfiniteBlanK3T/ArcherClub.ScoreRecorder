using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchersRecorderBackEndDatabase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archers",
                columns: table => new
                {
                    ArcherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GivenName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FamilyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archers", x => x.ArcherId);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentName);
                });

            migrationBuilder.CreateTable(
                name: "Ranges",
                columns: table => new
                {
                    RangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    NumberOfEnds = table.Column<int>(type: "int", nullable: false),
                    FaceSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranges", x => x.RangeID);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalArrows = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundId);
                });

            migrationBuilder.CreateTable(
                name: "RoundScores",
                columns: table => new
                {
                    RoundScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundId = table.Column<int>(type: "int", nullable: false),
                    ArcherId = table.Column<int>(type: "int", nullable: false),
                    EquipmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundScores", x => x.RoundScoreId);
                });

            migrationBuilder.CreateTable(
                name: "RoundRangeMappings",
                columns: table => new
                {
                    RoundId = table.Column<int>(type: "int", nullable: false),
                    RangeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundRangeMappings", x => new { x.RangeId, x.RoundId });
                    table.ForeignKey(
                        name: "FK_RoundRangeMappings_Ranges_RangeId",
                        column: x => x.RangeId,
                        principalTable: "Ranges",
                        principalColumn: "RangeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundRangeMappings_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ends",
                columns: table => new
                {
                    EndId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundScoreID = table.Column<int>(type: "int", nullable: false),
                    RangeID = table.Column<int>(type: "int", nullable: false),
                    ArrowScore1 = table.Column<int>(type: "int", nullable: false),
                    ArrowScore2 = table.Column<int>(type: "int", nullable: false),
                    ArrowScore3 = table.Column<int>(type: "int", nullable: false),
                    ArrowScore4 = table.Column<int>(type: "int", nullable: false),
                    ArrowScore5 = table.Column<int>(type: "int", nullable: false),
                    ArrowScore6 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ends", x => x.EndId);
                    table.ForeignKey(
                        name: "FK_Ends_Ranges_RangeID",
                        column: x => x.RangeID,
                        principalTable: "Ranges",
                        principalColumn: "RangeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ends_RoundScores_RoundScoreID",
                        column: x => x.RoundScoreID,
                        principalTable: "RoundScores",
                        principalColumn: "RoundScoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ends_RangeID",
                table: "Ends",
                column: "RangeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ends_RoundScoreID",
                table: "Ends",
                column: "RoundScoreID");

            migrationBuilder.CreateIndex(
                name: "IX_RoundRangeMappings_RoundId",
                table: "RoundRangeMappings",
                column: "RoundId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archers");

            migrationBuilder.DropTable(
                name: "Ends");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "RoundRangeMappings");

            migrationBuilder.DropTable(
                name: "RoundScores");

            migrationBuilder.DropTable(
                name: "Ranges");

            migrationBuilder.DropTable(
                name: "Rounds");
        }
    }
}
