using Aurora.DataAccess.Entities;
using Aurora.DomainProxy.Dtos;
using AutoMapper;

namespace Aurora.DomainProxy.Mappings
{
    public static class ToEntityMappings
    {
        private static IMapper _mapper;

        public static void RegisterMaps()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserRegisterDto, UserEntity>();
            });

            _mapper = config.CreateMapper();
        }

        public static UserEntity AsEntity(this UserRegisterDto dto)
        {
            return _mapper.Map<UserEntity>(dto);
        }
    }
}
