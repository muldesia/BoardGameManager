using System;
using AutoMapper;
using BoardGameManager.Domain.Entities;

namespace BoardGameManager.Domain.MapperProfiles
{
    public class EntityFrameworkToDomainProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "EntityFrameworkToDomainProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EntityFramework.Entities.BoardGame, BoardGame>();
            Mapper.CreateMap<EntityFramework.Entities.Person, Person>();
        }
    }
}