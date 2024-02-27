using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Migrations
{
    public partial class grand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Grant",
                table: "paymentSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MainR",
                table: "paymentSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "responsible",
                table: "paymentSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grant",
                table: "paymentSettings");

            migrationBuilder.DropColumn(
                name: "MainR",
                table: "paymentSettings");

            migrationBuilder.DropColumn(
                name: "responsible",
                table: "paymentSettings");
        }
    }
}
