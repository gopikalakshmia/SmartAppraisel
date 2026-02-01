using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL_SmartAppraisel.Migrations
{
    /// <inheritdoc />
    public partial class AddAssessmentResponses1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentResponses_AssessmentDetails_AssessmentID",
                table: "AssessmentResponses");

            migrationBuilder.DropIndex(
                name: "IX_AssessmentResponses_AssessmentID",
                table: "AssessmentResponses");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "AssessmentDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReviewed",
                table: "AssessmentDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "AssessmentDetails");

            migrationBuilder.DropColumn(
                name: "IsReviewed",
                table: "AssessmentDetails");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentResponses_AssessmentID",
                table: "AssessmentResponses",
                column: "AssessmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentResponses_AssessmentDetails_AssessmentID",
                table: "AssessmentResponses",
                column: "AssessmentID",
                principalTable: "AssessmentDetails",
                principalColumn: "AssessmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
