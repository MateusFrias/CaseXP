using CaseXP.Services.ProdutoDisponivelAPI.Models.Dto;

namespace CaseXP.Services.ProdutoDisponivelAPI.Service.IService
{
    public interface IProdutoDisponivelServico
    {
        Task<IEnumerable<ProdutoDisponivelDTO>> GetProdutosDisponiveis();
    }
}
