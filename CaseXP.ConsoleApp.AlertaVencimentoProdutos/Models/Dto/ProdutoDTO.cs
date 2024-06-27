using System.ComponentModel.DataAnnotations;

namespace CaseXP.Services.ProdutoDisponivelAPI.Models.Dto
{
    public class ProdutoDTO
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public DateOnly DataVencimento { get; set; }
        public int DiasLiquidez { get; set; }
        public double AplicacaoMinima { get; set; }
        public double TaxaAdm { get; set; }
        public string NivelRisco { get; set; }
        
    }
}
