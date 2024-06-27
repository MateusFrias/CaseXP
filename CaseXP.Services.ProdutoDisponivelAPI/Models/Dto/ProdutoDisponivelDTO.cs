using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CaseXP.Services.ProdutoDisponivelAPI.Models.Dto
{
    public class ProdutoDisponivelDTO
    {
        public int IdProdutoDisponivel { get; set; }
        public int IdProduto { get; set; }
        public ProdutoDTO? Produto { get; set; }
        public int IdUsuarioResponsavelProduto { get; set; } //foreign key para referência ao usuário responsável pela negociação do produto
        public int IdGrupoCliente { get; set; } //foreign key para grupos de categorização de clientes e direcionamento de público alvo
        public double TaxaAdm { get; set; } //taxa de administração pode variar pelo usuário que negocia e pelo públic alvo
        public DateOnly DataInicioVenda { get; set; }
        public DateOnly DataFimVenda { get; set; }
    }
}
