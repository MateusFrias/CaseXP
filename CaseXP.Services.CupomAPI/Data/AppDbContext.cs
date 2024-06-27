using CaseXP.Services.CupomAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseXP.Services.CupomAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Cupom> Cupons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cupom>().HasData(new Cupom
            {
                IdCupom = 1,
                CodigoCupom = "5OFF",
                Desconto = 5,
                ValorMinimo = 20
            });
            modelBuilder.Entity<Cupom>().HasData(new Cupom
            {
                IdCupom = 2,
                CodigoCupom = "10OFF",
                Desconto = 10,
                ValorMinimo = 40
            });
        }
    }
}
