using BoardGameManager.EntityFramework.Factories;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BoardGameManager.EntityFramework.Installers
{
    public class EntityFrameworkInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDbContextFactory>().ImplementedBy<BoardGameDbContextFactory>().LifeStyle.Transient);
        }
    }
}