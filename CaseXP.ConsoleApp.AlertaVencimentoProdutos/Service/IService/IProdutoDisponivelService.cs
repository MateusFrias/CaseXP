using CaseXP.ConsoleApp.AlertaVencimentoProdutos.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseXP.ConsoleApp.AlertaVencimentoProdutos.Service.IService
{
    public interface IProdutoDisponivelService
    {
        Task<IEnumerable<ProdutoDisponivelDTO>> GetProdutosDisponiveis();
    }
}
