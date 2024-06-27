using CaseXP.Services.ProdutoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseXP.Services.ProdutoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                IdProduto = 1,
                NomeProduto = "Fundo de Investimentos X1",
                Descricao = "Fundo de Investimento em ativos de FII e ações com dividendos",
                DataVencimento = new DateOnly(2026, 6, 1),
                DiasLiquidez = 365,
                AplicacaoMinima = 5000,
                TaxaAdm = 1.5,
                NivelRisco = "Médio"
            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                IdProduto = 2,
                NomeProduto = "Fundo Renda Fixa X2",
                Descricao = "Fundo CDB 120% CDI",
                DataVencimento = new DateOnly(2028, 12, 1),
                DiasLiquidez = 720,
                AplicacaoMinima = 10000,
                TaxaAdm = 1.2,
                NivelRisco = "Baixo"
            });
        }
    }
}
