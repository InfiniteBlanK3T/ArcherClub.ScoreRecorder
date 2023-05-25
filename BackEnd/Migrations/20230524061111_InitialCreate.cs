using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
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
                    BirthYear = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archers", x => x.ArcherId);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClubMaxedAge = table.Column<int>(type: "int", nullable: false),
                    ClubGender = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubName);
                });

            migrationBuilder.CreateTable(
                name: "Distances",
                columns: table => new
                {
                    Distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distances", x => x.Distance);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    EquipmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentID);
                });

            migrationBuilder.CreateTable(
                name: "EquivalentRounds",
                columns: table => new
                {
                    EquivalentRound = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberOfEndsPerRange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquivalentRounds", x => x.EquivalentRound);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "FaceSizes",
                columns: table => new
                {
                    FaceSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceSizes", x => x.FaceSize);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundEquivalent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundId);
                    table.ForeignKey(
                        name: "FK_Rounds_Clubs_ClubName",
                        column: x => x.ClubName,
                        principalTable: "Clubs",
                        principalColumn: "ClubName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rounds_EquivalentRounds_RoundEquivalent",
                        column: x => x.RoundEquivalent,
                        principalTable: "EquivalentRounds",
                        principalColumn: "EquivalentRound",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ranges",
                columns: table => new
                {
                    RangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    FaceSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranges", x => x.RangeID);
                    table.ForeignKey(
                        name: "FK_Ranges_Distances_Distance",
                        column: x => x.Distance,
                        principalTable: "Distances",
                        principalColumn: "Distance",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ranges_FaceSizes_FaceSize",
                        column: x => x.FaceSize,
                        principalTable: "FaceSizes",
                        principalColumn: "FaceSize",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultiEvent",
                columns: table => new
                {
                    MultiEventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    RoundID = table.Column<int>(type: "int", nullable: false),
                    ClubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiEvent", x => x.MultiEventID);
                    table.ForeignKey(
                        name: "FK_MultiEvent_Clubs_ClubName",
                        column: x => x.ClubName,
                        principalTable: "Clubs",
                        principalColumn: "ClubName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultiEvent_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultiEvent_Rounds_RoundID",
                        column: x => x.RoundID,
                        principalTable: "Rounds",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoundGroups",
                columns: table => new
                {
                    RoundGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundId = table.Column<int>(type: "int", nullable: false),
                    ClubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EquipmentID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundGroups", x => x.RoundGroupId);
                    table.ForeignKey(
                        name: "FK_RoundGroups_Clubs_ClubName",
                        column: x => x.ClubName,
                        principalTable: "Clubs",
                        principalColumn: "ClubName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundGroups_Equipments_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundGroups_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoundScore",
                columns: table => new
                {
                    RoundScoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArcherID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    RoundID = table.Column<int>(type: "int", nullable: false),
                    RoundDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquipmentID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EquipmentsEquipmentID = table.Column<string>(type: "nvarchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundScore", x => x.RoundScoreID);
                    table.ForeignKey(
                        name: "FK_RoundScore_Archers_ArcherID",
                        column: x => x.ArcherID,
                        principalTable: "Archers",
                        principalColumn: "ArcherId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundScore_Equipments_EquipmentsEquipmentID",
                        column: x => x.EquipmentsEquipmentID,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentID");
                    table.ForeignKey(
                        name: "FK_RoundScore_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundScore_Rounds_RoundID",
                        column: x => x.RoundID,
                        principalTable: "Rounds",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoundRangeMapping",
                columns: table => new
                {
                    RoundId = table.Column<int>(type: "int", nullable: false),
                    RangeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundRangeMapping", x => new { x.RoundId, x.RangeID });
                    table.ForeignKey(
                        name: "FK_RoundRangeMapping_Ranges_RangeID",
                        column: x => x.RangeID,
                        principalTable: "Ranges",
                        principalColumn: "RangeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundRangeMapping_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ends",
                columns: table => new
                {
                    EndID = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Ends", x => x.EndID);
                    table.ForeignKey(
                        name: "FK_Ends_Ranges_RangeID",
                        column: x => x.RangeID,
                        principalTable: "Ranges",
                        principalColumn: "RangeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ends_RoundScore_RoundScoreID",
                        column: x => x.RoundScoreID,
                        principalTable: "RoundScore",
                        principalColumn: "RoundScoreID",
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
                name: "IX_MultiEvent_ClubName",
                table: "MultiEvent",
                column: "ClubName");

            migrationBuilder.CreateIndex(
                name: "IX_MultiEvent_EventID",
                table: "MultiEvent",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_MultiEvent_RoundID",
                table: "MultiEvent",
                column: "RoundID");

            migrationBuilder.CreateIndex(
                name: "IX_Ranges_Distance",
                table: "Ranges",
                column: "Distance");

            migrationBuilder.CreateIndex(
                name: "IX_Ranges_FaceSize",
                table: "Ranges",
                column: "FaceSize");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGroups_ClubName",
                table: "RoundGroups",
                column: "ClubName");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGroups_EquipmentID",
                table: "RoundGroups",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGroups_RoundId",
                table: "RoundGroups",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundRangeMapping_RangeID",
                table: "RoundRangeMapping",
                column: "RangeID");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_ClubName",
                table: "Rounds",
                column: "ClubName");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_RoundEquivalent",
                table: "Rounds",
                column: "RoundEquivalent");

            migrationBuilder.CreateIndex(
                name: "IX_RoundScore_ArcherID",
                table: "RoundScore",
                column: "ArcherID");

            migrationBuilder.CreateIndex(
                name: "IX_RoundScore_EquipmentsEquipmentID",
                table: "RoundScore",
                column: "EquipmentsEquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_RoundScore_EventID",
                table: "RoundScore",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_RoundScore_RoundID",
                table: "RoundScore",
                column: "RoundID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ends");

            migrationBuilder.DropTable(
                name: "MultiEvent");

            migrationBuilder.DropTable(
                name: "RoundGroups");

            migrationBuilder.DropTable(
                name: "RoundRangeMapping");

            migrationBuilder.DropTable(
                name: "RoundScore");

            migrationBuilder.DropTable(
                name: "Ranges");

            migrationBuilder.DropTable(
                name: "Archers");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Distances");

            migrationBuilder.DropTable(
                name: "FaceSizes");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "EquivalentRounds");
        }
    }
}
