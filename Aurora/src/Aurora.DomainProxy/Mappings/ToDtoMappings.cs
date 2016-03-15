using AutoMapper;

namespace Aurora.DomainProxy.Mappings
{
    public static class ToDtoMappings
    {
        private static IMapper _mapper;

        public static void RegisterMaps()
        {
            var config = new MapperConfiguration(cfg =>
            {

            });

            _mapper = config.CreateMapper();
        }
    }
}
