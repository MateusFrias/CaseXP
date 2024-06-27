using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaseXP.Services.CupomAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCupomTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cupons",
                columns: new[] { "IdCupom", "CodigoCupom", "Desconto", "ValorMinimo" },
                values: new object[,]
                {
                    { 1, "5OFF", 5.0, 20 },
                    { 2, "10OFF", 10.0, 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cupons",
                keyColumn: "IdCupom",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cupons",
                keyColumn: "IdCupom",
                keyValue: 2);
        }
    }
}
