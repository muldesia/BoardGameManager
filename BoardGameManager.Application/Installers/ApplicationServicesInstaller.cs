using BoardGameManager.Application.Services;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameManager.Application.Installers
{
    public class ApplicationServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
               Component.For<IBoardGameGeekInfoCacheService>().ImplementedBy<BoardGameGeekInfoCacheService>().LifeStyle.Singleton);
        }
    }
}
