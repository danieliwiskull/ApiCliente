using AutoMapper;
using ClassLibraryEntities;
using WebApp.Models;

namespace WebApp.Configurations
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Cliente, ClienteViewModel>();
            });
            return mappingConfig;
        }
    }
}