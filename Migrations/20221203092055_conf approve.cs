using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Migrations
{
    public partial class confapprove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Amounts",
                table: "Conferences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Degrees",
                table: "Conferences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Departments",
                table: "Conferences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names",
                table: "Conferences",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amounts",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "Degrees",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "Departments",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "Names",
                table: "Conferences");
        }
    }
}
