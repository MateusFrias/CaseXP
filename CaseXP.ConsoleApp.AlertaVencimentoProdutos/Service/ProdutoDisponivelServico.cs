using CaseXP.ConsoleApp.AlertaVencimentoProdutos.Models.Dto;
using CaseXP.ConsoleApp.AlertaVencimentoProdutos.Service.IService;
//using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System.Net.Http;

namespace CaseXP.ConsoleApp.AlertaVencimentoProdutos.Service
{
    public class ProdutoDisponivelServico : IProdutoDisponivelService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProdutoDisponivelServico(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<IEnumerable<ProdutoDisponivelDTO>> GetProdutosDisponiveis()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("ProdutoDisponivel");
                var response = await client.GetAsync($"/api/produtodisponivel");
                var apiContent = await response.Content.ReadAsStringAsync();
                var resp = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                if (resp.IsSuccess)
                {
                    return JsonConvert.DeserializeObject<IEnumerable<ProdutoDisponivelDTO>>(Convert.ToString(resp.Result));
                }
                return new List<ProdutoDisponivelDTO>();
            }
            catch (Exception ex) { }
            return null;
        }
    }
}
