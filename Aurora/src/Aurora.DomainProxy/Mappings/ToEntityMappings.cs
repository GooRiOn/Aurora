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
                cfg.CreateMap<SprintWriteModel, SprintEntity>();
            });

            _mapper = config.CreateMapper();
        }

        public static UserEntity AsEntity(this UserRegisterWriteModel writeModel)
        {
            return _mapper.Map<UserEntity>(writeModel);
        }

        public static SprintEntity AsEntity(this SprintWriteModel writeModel)
        {
            return _mapper.Map<SprintEntity>(writeModel);
        }
    }
}
