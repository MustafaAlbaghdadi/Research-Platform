using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Migrations
{
    public partial class Conferenceextwihack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ConferencePrivertResearcher",
                table: "paymentSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ConferencepublicResearcher",
                table: "paymentSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "conferenceAcknowledgment",
                table: "paymentSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConferencePrivertResearcher",
                table: "paymentSettings");

            migrationBuilder.DropColumn(
                name: "ConferencepublicResearcher",
                table: "paymentSettings");

            migrationBuilder.DropColumn(
                name: "conferenceAcknowledgment",
                table: "paymentSettings");
        }
    }
}
