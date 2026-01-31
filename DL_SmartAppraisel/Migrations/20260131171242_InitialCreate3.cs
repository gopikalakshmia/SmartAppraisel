using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL_SmartAppraisel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentResponses",
                columns: table => new
                {
                    ResponseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentID = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Answer2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Answer3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Answer4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompetencyIDForQ1 = table.Column<int>(type: "int", nullable: false),
                    CompetencyIDForQ2 = table.Column<int>(type: "int", nullable: false),
                    CompetencyIDForQ3 = table.Column<int>(type: "int", nullable: false),
                    CompetencyIDForQ4 = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentResponses", x => x.ResponseID);
                    table.ForeignKey(
                        name: "FK_AssessmentResponses_AssessmentDetails_AssessmentID",
                        column: x => x.AssessmentID,
                        principalTable: "AssessmentDetails",
                        principalColumn: "AssessmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetencyDetails",
                columns: table => new
                {
                    CompID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetencyDetails", x => x.CompID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentResponses_AssessmentID",
                table: "AssessmentResponses",
                column: "AssessmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentResponses");

            migrationBuilder.DropTable(
                name: "CompetencyDetails");
        }
    }
}
