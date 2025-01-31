using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrail.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_AssignmentContentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                table: "AssignmentContents",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "FileUploadId",
                table: "AssignmentContents",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentContents_FileUploadId",
                table: "AssignmentContents",
                column: "FileUploadId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentContents_FileUploads_FileUploadId",
                table: "AssignmentContents",
                column: "FileUploadId",
                principalTable: "FileUploads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentContents_FileUploads_FileUploadId",
                table: "AssignmentContents");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentContents_FileUploadId",
                table: "AssignmentContents");

            migrationBuilder.DropColumn(
                name: "FileUploadId",
                table: "AssignmentContents");

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                table: "AssignmentContents",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
