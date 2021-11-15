using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LesegaisParser.Common.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SellerName = table.Column<string>(type: "TEXT", nullable: true),
                    SellerInn = table.Column<string>(type: "TEXT", nullable: true),
                    BuyerName = table.Column<string>(type: "TEXT", nullable: true),
                    BuyerInn = table.Column<string>(type: "TEXT", nullable: true),
                    WoodVolumeBuyer = table.Column<double>(type: "REAL", nullable: false),
                    WoodVolumeSeller = table.Column<double>(type: "REAL", nullable: false),
                    DealDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DealNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Typename = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deals");
        }
    }
}
