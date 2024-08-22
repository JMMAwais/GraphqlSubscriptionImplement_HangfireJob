using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphqlSubscriptionImplement_HangfireJob.Migrations
{
    /// <inheritdoc />
    public partial class ReArrangeForiegnkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendences_students_Student_ID",
                table: "attendences");

            migrationBuilder.RenameColumn(
                name: "Student_ID",
                table: "attendences",
                newName: "studentId");

            migrationBuilder.RenameIndex(
                name: "IX_attendences_Student_ID",
                table: "attendences",
                newName: "IX_attendences_studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_attendences_students_studentId",
                table: "attendences",
                column: "studentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendences_students_studentId",
                table: "attendences");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "attendences",
                newName: "Student_ID");

            migrationBuilder.RenameIndex(
                name: "IX_attendences_studentId",
                table: "attendences",
                newName: "IX_attendences_Student_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_attendences_students_Student_ID",
                table: "attendences",
                column: "Student_ID",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
