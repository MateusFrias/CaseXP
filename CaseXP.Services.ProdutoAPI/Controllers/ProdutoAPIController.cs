using AutoMapper;
using CaseXP.Services.ProdutoAPI.Data;
using CaseXP.Services.ProdutoAPI.Models;
using CaseXP.Services.ProdutoAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseXP.Services.ProdutoAPI.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;
        public ProdutoAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDTO();
        }
        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Produto> objList = _db.Produtos.ToList();
                _response.Result = _mapper.Map<IEnumerable<ProdutoDTO>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Produto obj = _db.Produtos.First(x => x.IdProduto == id);
                _response.Result = _mapper.Map<ProdutoDTO>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost]
        public ResponseDTO Post([FromBody] ProdutoDTO ProdutoDTO)
        {
            try
            {
                Produto produto = _mapper.Map<Produto>(ProdutoDTO);
                _db.Produtos.Add(produto);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ProdutoDTO>(produto);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPut]
        public ResponseDTO Put([FromBody] ProdutoDTO ProdutoDTO)
        {
            try
            {
                Produto Produto = _mapper.Map<Produto>(ProdutoDTO);
                _db.Produtos.Update(Produto);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ProdutoDTO>(Produto);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpDelete]
        public ResponseDTO Delete(int id)
        {
            try
            {
                Produto Produto = _db.Produtos.First(x => x.IdProduto == id);
                _db.Produtos.Remove(Produto);
                _db.SaveChanges();
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
