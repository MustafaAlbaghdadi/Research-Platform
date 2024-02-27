using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Migrations
{
    public partial class initialproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    depname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResearchId = table.Column<long>(type: "bigint", nullable: false),
                    quartileMoney = table.Column<long>(type: "bigint", nullable: true),
                    clarivateMoney = table.Column<long>(type: "bigint", nullable: true),
                    ExtResrchMoney = table.Column<long>(type: "bigint", nullable: true),
                    ThanksOFcollMoney = table.Column<long>(type: "bigint", nullable: true),
                    ImpactFacterMoney = table.Column<long>(type: "bigint", nullable: true),
                    SDGMoney = table.Column<long>(type: "bigint", nullable: true),
                    publishedMoney = table.Column<long>(type: "bigint", nullable: true),
                    openAccessMoney = table.Column<long>(type: "bigint", nullable: true),
                    femaleM = table.Column<long>(type: "bigint", nullable: true),
                    citationM = table.Column<long>(type: "bigint", nullable: true),
                    other = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total = table.Column<long>(type: "bigint", nullable: false),
                    scopusHumanDepartmentMoney = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paymentSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImpactFacterLargerThan5 = table.Column<int>(type: "int", nullable: false),
                    ImpactFacterFrom4To5 = table.Column<int>(type: "int", nullable: false),
                    ImpactFacterFrom3To4 = table.Column<int>(type: "int", nullable: false),
                    ImpactFacterFrom2To3 = table.Column<int>(type: "int", nullable: false),
                    ImpactFacterFrom1To2 = table.Column<int>(type: "int", nullable: false),
                    CitationLargerThen20 = table.Column<int>(type: "int", nullable: false),
                    CitationFrom16To20 = table.Column<int>(type: "int", nullable: false),
                    CitationFrom11To15 = table.Column<int>(type: "int", nullable: false),
                    CitationFrom8To10 = table.Column<int>(type: "int", nullable: false),
                    CitationFrom4To7 = table.Column<int>(type: "int", nullable: false),
                    CitationFrom1To3 = table.Column<int>(type: "int", nullable: false),
                    ScopusHumanDepartment = table.Column<int>(type: "int", nullable: false),
                    SDG = table.Column<int>(type: "int", nullable: false),
                    Q1First = table.Column<int>(type: "int", nullable: false),
                    Q2First = table.Column<int>(type: "int", nullable: false),
                    Q3First = table.Column<int>(type: "int", nullable: false),
                    Q4First = table.Column<int>(type: "int", nullable: false),
                    Q1Second = table.Column<int>(type: "int", nullable: false),
                    Q2Second = table.Column<int>(type: "int", nullable: false),
                    Q3Second = table.Column<int>(type: "int", nullable: false),
                    Q4Second = table.Column<int>(type: "int", nullable: false),
                    Female = table.Column<int>(type: "int", nullable: false),
                    openAccess = table.Column<int>(type: "int", nullable: false),
                    externalGloabalResearcher = table.Column<int>(type: "int", nullable: false),
                    externalLocalResearcher = table.Column<int>(type: "int", nullable: false),
                    ThanksForMustaqbal = table.Column<int>(type: "int", nullable: false),
                    inClarivate = table.Column<int>(type: "int", nullable: false),
                    publisher = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearchMUS",
                columns: table => new
                {
                    Form_No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ExtResrchDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SCOPUS_link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileRes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    published = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pubDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISSNorEISSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    journaltitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    journalurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quartile = table.Column<int>(type: "int", nullable: false),
                    citeScore = table.Column<double>(type: "float", nullable: false),
                    JournalCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rankOutOf = table.Column<int>(type: "int", nullable: true),
                    openAccess = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherResearch = table.Column<int>(type: "int", nullable: true),
                    appledPaper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    scopas = table.Column<bool>(type: "bit", nullable: true),
                    clarivate = table.Column<bool>(type: "bit", nullable: false),
                    viewlvl = table.Column<int>(type: "int", nullable: false),
                    publisherEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDGtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanksOFcoll = table.Column<bool>(type: "bit", nullable: true),
                    ImpactFacter = table.Column<double>(type: "float", nullable: true),
                    ExtResrch = table.Column<bool>(type: "bit", nullable: false),
                    ExtResrch_Local = table.Column<bool>(type: "bit", nullable: false),
                    ExtResrch_Globl = table.Column<bool>(type: "bit", nullable: false),
                    QRimage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    checkState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalMoney = table.Column<long>(type: "bigint", nullable: true),
                    scopusHumanDepartment = table.Column<bool>(type: "bit", nullable: true),
                    Names = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degrees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchMUS", x => x.Form_No);
                });

            migrationBuilder.CreateTable(
                name: "RR2tabel",
                columns: table => new
                {
                    ResearchId = table.Column<long>(type: "bigint", nullable: false),
                    ResearcherId = table.Column<long>(type: "bigint", nullable: false),
                    ResearcherLvl = table.Column<int>(type: "int", nullable: false),
                    ResearcherArName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearcherEnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearcherDeg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearcherDept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstPublished = table.Column<bool>(type: "bit", nullable: false),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearcherGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResearcherMoney = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RR2tabel", x => new { x.ResearchId, x.ResearcherId });
                });

            migrationBuilder.CreateTable(
                name: "TableCV",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    depid = table.Column<int>(type: "int", nullable: false),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableCV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DepTable");

            migrationBuilder.DropTable(
                name: "PaymentLog");

            migrationBuilder.DropTable(
                name: "paymentSettings");

            migrationBuilder.DropTable(
                name: "ResearchMUS");

            migrationBuilder.DropTable(
                name: "RR2tabel");

            migrationBuilder.DropTable(
                name: "TableCV");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
