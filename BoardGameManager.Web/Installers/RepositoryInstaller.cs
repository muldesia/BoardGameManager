using BoardGameManager.Domain.Repositories;
using BoardGameManager.EntityFramework;
using BoardGameManager.EntityFramework.DbContexts;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BoardGameManager.Web.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork<BoardGameDbContext>>().LifeStyle.Transient);

            container.Register(
                Component.For<IBoardGameRepository>().ImplementedBy<BoardGameRepository>().LifeStyle.Transient);
        }
    }
}