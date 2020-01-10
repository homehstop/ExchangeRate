using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidPrice = table.Column<float>(maxLength: 40, nullable: false),
                    AskPrice = table.Column<float>(maxLength: 40, nullable: false),
                    LastRefreshed = table.Column<string>(maxLength: 25, nullable: true),
                    ToCurrencyCode = table.Column<string>(maxLength: 15, nullable: true),
                    FromCurrencyCode = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyMonthlies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Published = table.Column<string>(nullable: false),
                    Open = table.Column<float>(maxLength: 40, nullable: false),
                    High = table.Column<float>(maxLength: 40, nullable: false),
                    Low = table.Column<float>(maxLength: 40, nullable: false),
                    Close = table.Column<float>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyMonthlies", x => new { x.Id, x.Published });
                    table.ForeignKey(
                        name: "FK_CurrencyMonthly_Currency",
                        column: x => x.Id,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyMonthlies");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
