using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Models.WriteModels;
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
                cfg.CreateMap<UserRegisterWriteModel, UserEntity>();
            });

            _mapper = config.CreateMapper();
        }

        public static UserEntity AsEntity(this UserRegisterWriteModel dto)
        {
            return _mapper.Map<UserEntity>(dto);
        }
    }
}
