using DataObjects.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;

namespace ClientWinforms
{
    public class SessionFactory
    {
        private ISessionFactory sessionFactory;
        
        SessionFactory()
        {
            sessionFactory = CreateSessionFactory();
        }

        public static SessionFactory Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        
        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly SessionFactory instance = new SessionFactory();
        }

        public ISession OpenSession()
        {
            return sessionFactory.OpenSession();
        }
        
        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString(c => c.Server("localhost").Database("nh3test").Username("root").Password("enginering")))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Customer>())
                .BuildConfiguration();

            return configuration.BuildSessionFactory();
        }
    }
}
