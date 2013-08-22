using AutoMapper;
using BoardGameManager.Domain.MapperProfiles;

namespace BoardGameManager.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<EntityFrameworkToDomainProfile>());
        }
    }
}