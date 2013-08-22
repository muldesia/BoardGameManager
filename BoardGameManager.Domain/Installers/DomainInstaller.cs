using BoardGameManager.Domain.Repositories;
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
                Component.For<IBoardGameRepository>().ImplementedBy<BoardGameRepository>().LifeStyle.Transient);
        }
    }
}