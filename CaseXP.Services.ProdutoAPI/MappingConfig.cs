using AutoMapper;
using CaseXP.Services.ProdutoAPI.Models;
using CaseXP.Services.ProdutoAPI.Models.Dto;

namespace CaseXP.Services.ProdutoAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProdutoDTO, Produto>();
                config.CreateMap<Produto, ProdutoDTO>();
            });
            return mappingConfig;
        }
    }
}
