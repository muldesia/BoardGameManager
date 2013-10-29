using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BoardGameManager.Application.DatabaseInitializers;
using BoardGameManager.Web.App_Start;
using Castle.Facilities.TypedFactory;
using Castle.Windsor;

namespace BoardGameManager.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private IWindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FormatterConfig.Configure(GlobalConfiguration.Configuration);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            WindsorConfig.Configure(out _container);

            AutoMapperConfig.Configure();

            Database.SetInitializer(new DropCreateBoardGameDatabaseInitializer());
        }
    }
}