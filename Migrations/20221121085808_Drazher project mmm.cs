using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Migrations
{
    public partial class Drazherprojectmmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResearcherAndCorresponding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uploaderEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Archive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearcherAndCorresponding", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearcherTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResearchTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResearchLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrespondingAuthors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResearcherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalResearcher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearcherEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JournalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalQuarter = table.Column<int>(type: "int", nullable: true),
                    ResearcherPosition = table.Column<int>(type: "int", nullable: true),
                    BatchNo = table.Column<int>(type: "int", nullable: true),
                    CorrPaidAmount = table.Column<int>(type: "int", nullable: true),
                    CorrPaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CorrRecipientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrReceivingSide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrPaidArder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearchAbstract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmountDesFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmountReceived = table.Column<int>(type: "int", nullable: true),
                    RecipientMoneyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Archive = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploaderEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdaterEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearcherTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResearcherAndCorresponding");

            migrationBuilder.DropTable(
                name: "ResearcherTable");
        }
    }
}
