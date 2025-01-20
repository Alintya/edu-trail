using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrail.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class StreamlineModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleContents_TrailModules_TrailModuleId",
                table: "ModuleContents");

            migrationBuilder.RenameColumn(
                name: "TrailModuleId",
                table: "ModuleContents",
                newName: "AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleContents_TrailModuleId",
                table: "ModuleContents",
                newName: "IX_ModuleContents_AssignmentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Assignments",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<bool>(
                name: "NeedsSubmission",
                table: "Assignments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Assignments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleContents_Assignments_AssignmentId",
                table: "ModuleContents",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleContents_Assignments_AssignmentId",
                table: "ModuleContents");

            migrationBuilder.DropColumn(
                name: "NeedsSubmission",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                table: "ModuleContents",
                newName: "TrailModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleContents_AssignmentId",
                table: "ModuleContents",
                newName: "IX_ModuleContents_TrailModuleId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Assignments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleContents_TrailModules_TrailModuleId",
                table: "ModuleContents",
                column: "TrailModuleId",
                principalTable: "TrailModules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
