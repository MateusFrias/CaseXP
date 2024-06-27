using CaseXP.Services.ProdutoDisponivelAPI.Models.Dto;

namespace CaseXP.Services.ProdutoDisponivelAPI.Service.IService
{
    public interface IProdutoServico
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutos();
    }
}
