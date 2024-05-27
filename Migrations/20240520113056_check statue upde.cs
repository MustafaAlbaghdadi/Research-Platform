using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Migrations
{
    public partial class checkstatueupde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderFormat",
                table: "ResearchMUS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResFormId",
                table: "ResearchMUS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScientificrRcommendation",
                table: "ResearchMUS",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderFormat",
                table: "ResearchMUS");

            migrationBuilder.DropColumn(
                name: "ResFormId",
                table: "ResearchMUS");

            migrationBuilder.DropColumn(
                name: "ScientificrRcommendation",
                table: "ResearchMUS");
        }
    }
}
