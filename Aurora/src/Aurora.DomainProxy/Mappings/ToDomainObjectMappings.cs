using Aurora.Domain.DomainObjects;
using Aurora.DomainProxy.Dtos;
using AutoMapper;

namespace Aurora.DomainProxy.Mappings
{
    public static class ToDomainObjectMappings
    {
        private static IMapper _mapper;

        public static void RegisterMaps()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserCreateDto, UserCreateDomainObject>();
                cfg.CreateMap<UserLoginDto, UserLoginDomainObject>();
                cfg.CreateMap<UserDto, UserDomainObject>();
            });

            _mapper = config.CreateMapper();
        }

        public static UserLoginDomainObject AsDomainObject(this UserLoginDto dto)
        {
            return _mapper.Map<UserLoginDomainObject>(dto);
        }

        public static UserCreateDomainObject AsDomainObject(this UserCreateDto dto)
        {
            return _mapper.Map<UserCreateDomainObject>(dto);
        }

        public static UserDomainObject AsDomainObject(this UserDto dto)
        {
            return _mapper.Map<UserDomainObject>(dto);
        }
    }
}
