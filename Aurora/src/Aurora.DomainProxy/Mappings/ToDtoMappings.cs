using Aurora.Domain.DomainObjects;
using Aurora.DomainProxy.Dtos;
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
                cfg.CreateMap<UserSelfInfoDomainObject, UserSelfInfoDto>();
            });

            _mapper = config.CreateMapper();
        }

        public static UserSelfInfoDto AsDto(this UserSelfInfoDomainObject that)
        {
            return _mapper.Map<UserSelfInfoDto>(that);
        }
    }
}
