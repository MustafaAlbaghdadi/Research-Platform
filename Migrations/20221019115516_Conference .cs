using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Migrations
{
    public partial class Conference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ConferenceFirst",
                table: "paymentSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ConferenceSecend",
                table: "paymentSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ConferenceResearches",
                columns: table => new
                {
                    ConferenceId = table.Column<long>(type: "bigint", nullable: false),
                    ResearcherId = table.Column<long>(type: "bigint", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DepartmentTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResearcherArName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearcherEnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearcherDeg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstPublished = table.Column<bool>(type: "bit", nullable: false),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearcherGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResearcherMoney = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceResearches", x => new { x.ConferenceId, x.ResearcherId });
                });

            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    ResearchTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attach1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attach2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriviteCollege = table.Column<bool>(type: "bit", nullable: false),
                    PublicCollege = table.Column<bool>(type: "bit", nullable: false),
                    GlobalCollege = table.Column<bool>(type: "bit", nullable: false),
                    Acknowledge = table.Column<bool>(type: "bit", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RejectReson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploaderEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QRImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConferenceResearches");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropColumn(
                name: "ConferenceFirst",
                table: "paymentSettings");

            migrationBuilder.DropColumn(
                name: "ConferenceSecend",
                table: "paymentSettings");
        }
    }
}
