using CaseXP.Services.ProdutoDisponivelAPI.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseXP.Services.ProdutoDisponivelAPI.Models
{
    public class ProdutoDisponivel
    {
        [Key]
        public int IdProdutoDisponivel { get; set; }
        [Required]
        public int IdProduto { get; set; }
        [NotMapped]
        public ProdutoDTO Produto { get; set; }
        public int IdUsuarioResponsavelProduto { get; set; } //foreign key para referência ao usuário responsável pela negociação do produto
        public int IdGrupoPublicoAlvoProduto { get; set; } //foreign key para grupos de categorização de clientes e direcionamento de público alvo
        public double TaxaAdm {  get; set; }
        public DateOnly DataInicioVenda { get; set; }
        public DateOnly DataFimVenda { get; set; }
    }
}
