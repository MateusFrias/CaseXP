using AutoMapper;
using CaseXP.Services.ProdutoDisponivelAPI.Models;
using CaseXP.Services.ProdutoDisponivelAPI.Models.Dto;

namespace CaseXP.Services.ProdutoDisponivelAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProdutoDisponivelDTO, ProdutoDisponivel>();
                config.CreateMap<ProdutoDisponivel, ProdutoDisponivelDTO>();
            });
            return mappingConfig;
        }
    }
}
