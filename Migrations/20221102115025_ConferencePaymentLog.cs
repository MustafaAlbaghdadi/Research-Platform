using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Migrations
{
    public partial class ConferencePaymentLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferencePaymentLogs",
                table: "ConferencePaymentLogs");

            migrationBuilder.RenameTable(
                name: "ConferencePaymentLogs",
                newName: "ConferencePaymentLog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferencePaymentLog",
                table: "ConferencePaymentLog",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferencePaymentLog",
                table: "ConferencePaymentLog");

            migrationBuilder.RenameTable(
                name: "ConferencePaymentLog",
                newName: "ConferencePaymentLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferencePaymentLogs",
                table: "ConferencePaymentLogs",
                column: "Id");
        }
    }
}
