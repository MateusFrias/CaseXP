using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseXP.Services.ProdutoDisponivelAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProdutoDisponivelAndSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutosDisponiveis",
                columns: table => new
                {
                    IdProdutoDisponivel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioResponsavelProduto = table.Column<int>(type: "int", nullable: false),
                    IdGrupoPublicoAlvoProduto = table.Column<int>(type: "int", nullable: false),
                    TaxaAdm = table.Column<double>(type: "float", nullable: false),
                    DataInicioVenda = table.Column<DateOnly>(type: "date", nullable: false),
                    DataFimVenda = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosDisponiveis", x => x.IdProdutoDisponivel);
                });

            migrationBuilder.InsertData(
                table: "ProdutosDisponiveis",
                columns: new[] { "IdProdutoDisponivel", "DataFimVenda", "DataInicioVenda", "IdGrupoPublicoAlvoProduto", "IdProduto", "IdUsuarioResponsavelProduto", "TaxaAdm" },
                values: new object[] { 1, new DateOnly(2024, 6, 30), new DateOnly(2024, 6, 1), 10, 1, 50, 1.5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosDisponiveis");
        }
    }
}
