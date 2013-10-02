using AutoMapper;
using BoardGameManager.Domain.MapperProfiles;
using BoardGameManager.Web.MapperProfiles;

namespace BoardGameManager.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x => {    
                                x.AddProfile<EntityFrameworkToDomainProfile>();
                                x.AddProfile<DomainToViewModelProfile>();
            });
        }
    }
}