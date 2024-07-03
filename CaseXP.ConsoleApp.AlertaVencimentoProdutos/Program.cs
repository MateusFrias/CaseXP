using AutoMapper;
using CaseXP.ConsoleApp.AlertaVencimentoProdutos.Models.Dto;
using CaseXP.ConsoleApp.AlertaVencimentoProdutos.Service;
using CaseXP.ConsoleApp.AlertaVencimentoProdutos.Service.IService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CaseXP.ConsoleApp.AlertaVencimentoProdutos
{
    internal class Program
    {
        private ResponseDTO _response = new();
        //private IMapper _mapper;
        //private IProdutoDisponivelService _produtoServico;
        private static Program program = new Program();
        static IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
            services => {
                //services.AddSingleton<IMapper, Mapper>();
                services.AddSingleton<IProdutoDisponivelService, ProdutoDisponivelServico>();
                services.AddHttpClient("ProdutoDisponivel", x => x.BaseAddress = new Uri("https://localhost:7002"));
            })
            .Build();
        static async Task Main(string[] args)
        {
            var produtoService = _host.Services.GetRequiredService<IProdutoDisponivelService>();

            program.EnviaEmailAlerta(1, produtoService);

            Console.ReadLine();
        }
        private async void EnviaEmailAlerta(int diasVencimento, IProdutoDisponivelService produtoService)
        {
            var emailService = new EmailService();

            var listaProdutos = await GetProdutosComVencimentoProximo(diasVencimento, produtoService);

            foreach (var produto in listaProdutos)
            {
                emailService.SendEmail(
                    "mateusmfrias@gmail.com",
                    "Sistema Gestão de Portfolio - Produto prestes a vencer!",
                    "Prezado " + produto.IdUsuarioResponsavelProduto.ToString() + ", bom dia!" +
                    "\nA data de vencimento do produto " + produto.Produto.NomeProduto + " se aproxima: ele vencerá em " +
                    produto.DataFimVenda.ToString() + ".");
            }
        }

        private async Task<IEnumerable<ProdutoDisponivelDTO>> GetProdutosComVencimentoProximo(int diasParaVencimento, IProdutoDisponivelService produtoService)
        {
            try
            {
                IEnumerable<ProdutoDisponivelDTO> produtos = await produtoService.GetProdutosDisponiveis();

                var dataVencimentoLimite = DateOnly.FromDateTime(DateTime.Now.AddDays(diasParaVencimento * -1));
                produtos = produtos.Where(x => x.DataFimVenda <= dataVencimentoLimite).ToList();
               
                return produtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return null;
        }
    }
}
