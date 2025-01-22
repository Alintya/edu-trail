using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrail.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_FileUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "FileUploads");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "FileUploads",
                newName: "StorageIdentifier");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "FileUploads",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "FileUploads");

            migrationBuilder.RenameColumn(
                name: "StorageIdentifier",
                table: "FileUploads",
                newName: "FileName");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "FileUploads",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }
    }
}
