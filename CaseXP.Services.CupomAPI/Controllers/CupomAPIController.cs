using AutoMapper;
using CaseXP.Services.CupomAPI.Data;
using CaseXP.Services.CupomAPI.Models;
using CaseXP.Services.CupomAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseXP.Services.CupomAPI.Controllers
{
    [Route("api/cupom")]
    [ApiController]
    public class CupomAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;
        public CupomAPIController(AppDbContext db, IMapper mapper)
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
                IEnumerable<Cupom> objList = _db.Cupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CupomDTO>>(objList);
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
                Cupom obj = _db.Cupons.First(x => x.IdCupom == id);
                _response.Result = _mapper.Map<CupomDTO>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost]
        public ResponseDTO Post([FromBody] CupomDTO cupomDTO)
        {
            try
            {
                Cupom cupom = _mapper.Map<Cupom>(cupomDTO);
                _db.Cupons.Add(cupom);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CupomDTO>(cupom);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPut]
        public ResponseDTO Put([FromBody] CupomDTO cupomDTO)
        {
            try
            {
                Cupom cupom = _mapper.Map<Cupom>(cupomDTO);
                _db.Cupons.Update(cupom);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CupomDTO>(cupom);

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
                Cupom cupom = _db.Cupons.First(x => x.IdCupom == id);
                _db.Cupons.Remove(cupom);
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
