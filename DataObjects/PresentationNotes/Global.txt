using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DataObjects.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;

namespace ClientAspMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory SessionFactory { get; private set; }
        
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            SessionFactory = CreateSessionFactory();
            
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(SessionFactory);
            session.Dispose();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString (c => c.Server("localhost").Database("nh3test").Username("root").Password("enginering"))
                    .CurrentSessionContext<WebSessionContext>() )
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Customer>())
                .BuildConfiguration();

            return configuration.BuildSessionFactory();
        }
    }
}