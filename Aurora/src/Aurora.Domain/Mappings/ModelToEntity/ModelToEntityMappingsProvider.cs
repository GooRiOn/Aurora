using System;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Models;
using AutoMapper;

namespace Aurora.Domain.Mappings.ModelToEntity
{
    public static class ModelToEntityMappingsProvider
    {
        private static IMapper _mapper;
        public static void RegisterMaps()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserCreateModel, UserEntity>();
            });

            _mapper = config.CreateMapper();
        }

        public static UserEntity AsEntity(this UserCreateModel that)
        {
            return _mapper.Map<UserEntity>(that);
        }
    }
}
