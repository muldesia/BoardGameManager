using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using BoardGameManager.Web.Windsor;
using Castle.Windsor;
using Castle.Windsor.Installer;
using BoardGameManager.Application.Installers;
using BoardGameManager.Web.Installers;

namespace BoardGameManager.Web.App_Start
{
    public static class WindsorConfig
    {
        public static void Configure(out IWindsorContainer container)
        {
            container = new WindsorContainer().Install(FromAssembly.This(), FromAssembly.Containing<DomainRepositoryInstaller>());

            //MVC
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            //Web API
            GlobalConfiguration.Configuration.Services.Replace(typeof (IHttpControllerActivator),
                new WindsorWebApiControllerActivator(container));
        }
    }
}