using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphqlSubscriptionImplement_HangfireJob.Migrations
{
    /// <inheritdoc />
    public partial class addDateField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendences_students_studentId",
                table: "attendences");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "attendences",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "attendences",
                type: "date",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_attendences_students_studentId",
                table: "attendences",
                column: "studentId",
                principalTable: "students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendences_students_studentId",
                table: "attendences");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "attendences");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "attendences",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_attendences_students_studentId",
                table: "attendences",
                column: "studentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
