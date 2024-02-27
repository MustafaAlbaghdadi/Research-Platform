using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Migrations
{
    public partial class attachedFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "attachedFile1",
                table: "ResearchMUS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "attachedFile2",
                table: "ResearchMUS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "attachedFile3",
                table: "ResearchMUS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "attachedFile4",
                table: "ResearchMUS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "attachedFile1",
                table: "ResearchMUS");

            migrationBuilder.DropColumn(
                name: "attachedFile2",
                table: "ResearchMUS");

            migrationBuilder.DropColumn(
                name: "attachedFile3",
                table: "ResearchMUS");

            migrationBuilder.DropColumn(
                name: "attachedFile4",
                table: "ResearchMUS");
        }
    }
}
