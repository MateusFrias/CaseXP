using CaseXP.Services.ProdutoDisponivelAPI.Models.Dto;
using CaseXP.Services.ProdutoDisponivelAPI.Service.IService;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;

namespace CaseXP.Services.ProdutoDisponivelAPI.Service
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProdutoServico(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var client = _httpClientFactory.CreateClient("Produto");
            var response = await client.GetAsync($"/api/produto");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProdutoDTO>>(Convert.ToString(resp.Result));
            }
            return new List<ProdutoDTO>();
        }
    }
}
