using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrail.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixStudentProgress_Mapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProgress_ModuleContents_ModuleContentId",
                table: "StudentProgress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProgress",
                table: "StudentProgress");

            migrationBuilder.DropIndex(
                name: "IX_StudentProgress_StudentId",
                table: "StudentProgress");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentProgress");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "StudentProgress");

            migrationBuilder.RenameColumn(
                name: "ModuleContentId",
                table: "StudentProgress",
                newName: "AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProgress_ModuleContentId",
                table: "StudentProgress",
                newName: "IX_StudentProgress_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProgress",
                table: "StudentProgress",
                columns: new[] { "StudentId", "AssignmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProgress_Assignments_AssignmentId",
                table: "StudentProgress",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProgress_Assignments_AssignmentId",
                table: "StudentProgress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProgress",
                table: "StudentProgress");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                table: "StudentProgress",
                newName: "ModuleContentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProgress_AssignmentId",
                table: "StudentProgress",
                newName: "IX_StudentProgress_ModuleContentId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "StudentProgress",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "StudentProgress",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProgress",
                table: "StudentProgress",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgress_StudentId",
                table: "StudentProgress",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProgress_ModuleContents_ModuleContentId",
                table: "StudentProgress",
                column: "ModuleContentId",
                principalTable: "ModuleContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
