using AutoMapper;
using CaseXP.Services.ProdutoDisponivelAPI.Data;
using CaseXP.Services.ProdutoDisponivelAPI.Models;
using CaseXP.Services.ProdutoDisponivelAPI.Models.Dto;
using CaseXP.Services.ProdutoDisponivelAPI.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseXP.Services.ProdutoDisponivelAPI.Controllers
{
    [Route("api/produtodisponivel")]
    [ApiController]
    public class ProdutoDisponivelController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;
        private IProdutoServico _produtoServico;
        public ProdutoDisponivelController(AppDbContext db, IMapper mapper, IProdutoServico produtoServico)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDTO();
            _produtoServico = produtoServico;
        }
        [HttpPost]
        public ResponseDTO Post([FromBody] ProdutoDisponivelDTO produtoDisponivelDTO)
        {
            try
            {
                ProdutoDisponivel produto = _mapper.Map<ProdutoDisponivel>(produtoDisponivelDTO);
                _db.ProdutosDisponiveis.Add(produto);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ProdutoDisponivelDTO>(produto);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPut]
        public ResponseDTO Put([FromBody] ProdutoDisponivelDTO produtoDisponivelDTO)
        {
            try
            {
                ProdutoDisponivel produto = _mapper.Map<ProdutoDisponivel>(produtoDisponivelDTO);
                _db.ProdutosDisponiveis.Update(produto);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ProdutoDisponivelDTO>(produto);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            try
            {
                IEnumerable<ProdutoDisponivel> produtosDisponiveis = _db.ProdutosDisponiveis.ToList();
                IEnumerable<ProdutoDTO> produtos = await _produtoServico.GetProdutos();

                foreach (var produtoDisponivel in produtosDisponiveis)
                {
                    produtoDisponivel.Produto = produtos.FirstOrDefault(x => x.IdProduto == produtoDisponivel.IdProduto);
                }
                
                _response.Result = _mapper.Map<IEnumerable<ProdutoDisponivelDTO>>(produtosDisponiveis);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
