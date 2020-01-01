using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyRates",
                columns: table => new
                {
                    CurrencyRateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiUrl = table.Column<string>(maxLength: 200, nullable: true),
                    BidPrice = table.Column<float>(maxLength: 40, nullable: false),
                    AskPrice = table.Column<float>(maxLength: 40, nullable: false),
                    LastRefreshed = table.Column<string>(maxLength: 25, nullable: true),
                    ToCurrencyCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRates", x => x.CurrencyRateId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyRateId = table.Column<int>(nullable: false),
                    CurrencyName = table.Column<string>(maxLength: 50, nullable: true),
                    CurrencyCode = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Currency_CurrencyRate",
                        column: x => x.CurrencyRateId,
                        principalTable: "CurrencyRates",
                        principalColumn: "CurrencyRateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyMonthlies",
                columns: table => new
                {
                    CurrencyMonthlyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(nullable: false),
                    LastRefreshed = table.Column<string>(maxLength: 25, nullable: true),
                    MonthlyApiUrl = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyMonthlies", x => x.CurrencyMonthlyId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_CurrencyMontly_Currency",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monthlies",
                columns: table => new
                {
                    MonthlyId = table.Column<int>(nullable: false),
                    Published = table.Column<string>(maxLength: 25, nullable: true),
                    Open = table.Column<float>(maxLength: 40, nullable: false),
                    High = table.Column<float>(maxLength: 40, nullable: false),
                    Low = table.Column<float>(maxLength: 40, nullable: false),
                    Close = table.Column<float>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monthlies", x => x.MonthlyId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Montly_CurrencyMontly",
                        column: x => x.MonthlyId,
                        principalTable: "CurrencyMonthlies",
                        principalColumn: "CurrencyMonthlyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CurrencyRateId",
                table: "Currencies",
                column: "CurrencyRateId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyMonthlies_CurrencyId",
                table: "CurrencyMonthlies",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monthlies");

            migrationBuilder.DropTable(
                name: "CurrencyMonthlies");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "CurrencyRates");
        }
    }
}
