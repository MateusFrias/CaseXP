using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaseXP.Services.ProdutoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProdutoAndSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataVencimento = table.Column<DateOnly>(type: "date", nullable: false),
                    DiasLiquidez = table.Column<int>(type: "int", nullable: false),
                    AplicacaoMinima = table.Column<double>(type: "float", nullable: false),
                    TaxaAdm = table.Column<double>(type: "float", nullable: false),
                    NivelRisco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "IdProduto", "AplicacaoMinima", "DataVencimento", "Descricao", "DiasLiquidez", "NivelRisco", "NomeProduto", "TaxaAdm" },
                values: new object[,]
                {
                    { 1, 5000.0, new DateOnly(2026, 6, 1), "Fundo de Investimento em ativos de FII e ações com dividendos", 365, "Médio", "Fundo de Investimentos X1", 1.5 },
                    { 2, 10000.0, new DateOnly(2028, 12, 1), "Fundo CDB 120% CDI", 720, "Baixo", "Fundo Renda Fixa X2", 1.2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
