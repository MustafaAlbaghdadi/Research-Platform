using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Migrations
{
    public partial class Conferencechangetolocalandglobal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConferencepublicResearcher",
                table: "paymentSettings",
                newName: "ConferenceLocalResearcher");

            migrationBuilder.RenameColumn(
                name: "ConferencePrivertResearcher",
                table: "paymentSettings",
                newName: "ConferenceGlobalResearcher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConferenceLocalResearcher",
                table: "paymentSettings",
                newName: "ConferencepublicResearcher");

            migrationBuilder.RenameColumn(
                name: "ConferenceGlobalResearcher",
                table: "paymentSettings",
                newName: "ConferencePrivertResearcher");
        }
    }
}
