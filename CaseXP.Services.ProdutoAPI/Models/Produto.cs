using System.ComponentModel.DataAnnotations;

namespace CaseXP.Services.ProdutoAPI.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        [Required]
        public string NomeProduto { get; set; }
        [Required]
        public string Descricao { get; set; }
        public DateOnly DataVencimento { get; set; }
        public int DiasLiquidez { get; set; }
        [Required]
        public double AplicacaoMinima { get; set; }
        [Required]
        public double TaxaAdm { get; set; }
        [Required]
        public string NivelRisco { get; set; }
        
    }
}
