using Microsoft.EntityFrameworkCore.Migrations;

namespace ExchangeRate.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(nullable: true),
                    CurrencyCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "ToCurrency",
                columns: table => new
                {
                    ToCurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToCurrencyName = table.Column<string>(nullable: true),
                    ExchangeRate = table.Column<float>(nullable: false),
                    BidPrice = table.Column<float>(nullable: false),
                    AskPrice = table.Column<float>(nullable: false),
                    LastRefreshed = table.Column<string>(nullable: true),
                    ToCurrency = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToCurrency", x => x.ToCurrencyId);
                    table.ForeignKey(
                        name: "FK_ToCurrency_Currencies_ToCurrency",
                        column: x => x.ToCurrency,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyMonthly",
                columns: table => new
                {
                    CurrencyMonthlyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastRefreshed = table.Column<string>(nullable: true),
                    Currency = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyMonthly", x => x.CurrencyMonthlyId);
                    table.ForeignKey(
                        name: "FK_CurrencyMonthly_ToCurrency_Currency",
                        column: x => x.Currency,
                        principalTable: "ToCurrency",
                        principalColumn: "ToCurrencyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Monthly",
                columns: table => new
                {
                    MonthlyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Open = table.Column<float>(nullable: false),
                    High = table.Column<float>(nullable: false),
                    Low = table.Column<float>(nullable: false),
                    Close = table.Column<float>(nullable: false),
                    ToCurrency = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monthly", x => x.MonthlyId);
                    table.ForeignKey(
                        name: "FK_Monthly_CurrencyMonthly_ToCurrency",
                        column: x => x.ToCurrency,
                        principalTable: "CurrencyMonthly",
                        principalColumn: "CurrencyMonthlyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyMonthly_Currency",
                table: "CurrencyMonthly",
                column: "Currency");

            migrationBuilder.CreateIndex(
                name: "IX_Monthly_ToCurrency",
                table: "Monthly",
                column: "ToCurrency");

            migrationBuilder.CreateIndex(
                name: "IX_ToCurrency_ToCurrency",
                table: "ToCurrency",
                column: "ToCurrency");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monthly");

            migrationBuilder.DropTable(
                name: "CurrencyMonthly");

            migrationBuilder.DropTable(
                name: "ToCurrency");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
