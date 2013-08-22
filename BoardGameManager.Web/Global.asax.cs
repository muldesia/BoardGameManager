﻿using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BoardGameManager.Application.DatabaseInitializers;
using BoardGameManager.Domain.Installers;
using BoardGameManager.EntityFramework.Installers;
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

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FormatterConfig.Configure(GlobalConfiguration.Configuration);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            WindsorConfig.Configure(out _container);
            //_container.Install(new EntityFrameworkInstaller());
            //_container.Install(new DomainInstaller());

            AutoMapperConfig.Configure();

            Database.SetInitializer(new DropCreateBoardGameDatabaseInitializer());
        }
    }
}