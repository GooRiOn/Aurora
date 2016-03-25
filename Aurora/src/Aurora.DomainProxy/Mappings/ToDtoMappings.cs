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
                cfg.CreateMap<UserDomainObject, UserDto>();
            });

            _mapper = config.CreateMapper();
        }

        public static UserSelfInfoDto AsDto(this UserSelfInfoDomainObject that)
        {
            return _mapper.Map<UserSelfInfoDto>(that);
        }

        public static UserDto AsDto(this UserDomainObject that)
        {
            return _mapper.Map<UserDto>(that);
        }
    }
}
