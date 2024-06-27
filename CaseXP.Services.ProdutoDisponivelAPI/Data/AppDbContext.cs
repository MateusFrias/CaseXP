using CaseXP.Services.ProdutoDisponivelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseXP.Services.ProdutoDisponivelAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ProdutoDisponivel> ProdutosDisponiveis { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProdutoDisponivel>().HasData(new ProdutoDisponivel
            {
                IdProdutoDisponivel = 1,
                IdProduto = 1,
                IdGrupoPublicoAlvoProduto = 10,
                IdUsuarioResponsavelProduto= 50,
                TaxaAdm = 1.5,
                DataInicioVenda = new DateOnly(2024, 6, 1),
                DataFimVenda = new DateOnly(2024, 6, 30)
                });
        }
    }
}
