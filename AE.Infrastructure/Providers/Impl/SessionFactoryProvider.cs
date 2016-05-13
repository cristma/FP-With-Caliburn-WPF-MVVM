using AE.Infrastructure.FlightProcedures.Repositories.Impl.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace AE.Infrastructure.Providers.Impl
{
    internal class SessionFactoryProvider : ISessionFactoryProvider
    {
        private ISessionFactory sessionFactoryCache;

        public SessionFactoryProvider()
        {
            this.sessionFactoryCache = null;
        }

        public ISessionFactory ForWorkspace()
        {
            if (sessionFactoryCache != null)
                return sessionFactoryCache;

            ISessionFactory factory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.Raw("hbm2ddl.keywords", "none")
                .ConnectionString(c => c.Server("localhost")
                                        .Database("production")
                                        .Username("immutable")
                                        .Password("simulation")))
                .ExposeConfiguration(cfg =>
                    {
                        //new SchemaExport(cfg).Create(false, true);
                        new SchemaUpdate(cfg).Execute(false, true);
                    })
                .Mappings(m => m.FluentMappings
                    .Add<NHApproachDtoMapping>()
                    .Add<NHEsaDtoMapping>())
                .BuildSessionFactory();

            this.sessionFactoryCache = factory;

            return factory;
        }
    }
}