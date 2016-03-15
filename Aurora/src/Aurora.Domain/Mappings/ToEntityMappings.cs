using Aurora.DataAccess.Entities;
using Aurora.Domain.DomainObjects;
using AutoMapper;

namespace Aurora.Domain.Mappings
{
    public static class ToEntityMappings
    {
        private static IMapper _mapper;

        public static void RegisterMaps()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserCreateDomainObject, UserEntity>();
            });

            _mapper = config.CreateMapper();
        }

        public static UserEntity AsEntity(this UserCreateDomainObject domainObject)
        {
            return _mapper.Map<UserEntity>(domainObject);
        }
    }
}
