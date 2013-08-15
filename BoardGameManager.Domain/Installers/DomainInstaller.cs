using BoardGameManager.Domain.Entities;
using BoardGameManager.Domain.Factories;
using BoardGameManager.EntityFramework.Factories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BoardGameManager.Domain.Installers
{
    public class DomainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDbContextFactory>().ImplementedBy<BoardGameDbContextFactory>().LifeStyle.Transient);
            container.Register(Component.For<IBoardGameFactory>().ImplementedBy<BoardGameFactory>().LifeStyle.Transient);
        }
    }
}