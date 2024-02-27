using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Migrations
{
    public partial class mmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MainR",
                table: "RR2tabel",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "responsible",
                table: "RR2tabel",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GrantInfo",
                table: "ResearchMUS",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GrantMoney",
                table: "PaymentLog",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MainRMoney",
                table: "PaymentLog",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "responsibleMoney",
                table: "PaymentLog",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainR",
                table: "RR2tabel");

            migrationBuilder.DropColumn(
                name: "responsible",
                table: "RR2tabel");

            migrationBuilder.DropColumn(
                name: "GrantInfo",
                table: "ResearchMUS");

            migrationBuilder.DropColumn(
                name: "GrantMoney",
                table: "PaymentLog");

            migrationBuilder.DropColumn(
                name: "MainRMoney",
                table: "PaymentLog");

            migrationBuilder.DropColumn(
                name: "responsibleMoney",
                table: "PaymentLog");
        }
    }
}
