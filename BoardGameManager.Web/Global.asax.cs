using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BoardGameManager.Application.DatabaseInitializers;
using BoardGameManager.Domain.Installers;
using BoardGameManager.EntityFramework.Installers;
using Castle.Facilities.TypedFactory;
using Castle.Windsor;

namespace BoardGameManager.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private WindsorContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            container = new WindsorContainer();
            container.Install(new EntityFrameworkInstaller());
            container.Install(new DomainInstaller());

            Database.SetInitializer(new DropCreateBoardGameDatabaseInitializer());
        }
    }
}