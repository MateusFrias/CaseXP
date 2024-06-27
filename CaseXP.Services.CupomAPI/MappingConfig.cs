using AutoMapper;
using CaseXP.Services.CupomAPI.Models;
using CaseXP.Services.CupomAPI.Models.Dto;

namespace CaseXP.Services.CupomAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CupomDTO, Cupom>();
                config.CreateMap<Cupom, CupomDTO>();
            });
            return mappingConfig;
        }
    }
}
