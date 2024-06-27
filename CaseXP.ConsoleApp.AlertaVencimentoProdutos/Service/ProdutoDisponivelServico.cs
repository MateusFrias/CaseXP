using CaseXP.Services.ProdutoDisponivelAPI.Models.Dto;
using CaseXP.Services.ProdutoDisponivelAPI.Service.IService;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace CaseXP.Services.ProdutoDisponivelAPI.Service
{
    public class ProdutoDisponivelServico : IProdutoDisponivelServico
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProdutoDisponivelServico(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<IEnumerable<ProdutoDisponivelDTO>> GetProdutosDisponiveis()
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var response = await client.GetAsync($"https://localhost:7002/api/produtodisponivel");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProdutoDisponivelDTO>>(Convert.ToString(resp.Result));
            }
            return new List<ProdutoDisponivelDTO>();
        }
    }
}
