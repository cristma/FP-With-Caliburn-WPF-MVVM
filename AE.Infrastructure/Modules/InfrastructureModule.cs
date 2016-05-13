using AE.FlightProcedures.Domain.Approaches.Repositories;
using AE.FlightProcedures.Domain.Segments.Repositories;
using AE.Infrastructure.FlightProcedures.Repositories.Impl;
using AE.Infrastructure.Providers;
using AE.Infrastructure.Providers.Impl;
using Autofac;

namespace AE.Infrastructure.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApproachRepository>().As<IApproachRepository>();
            builder.RegisterType<EsaRepository>().As<IEsaRepository>();
            builder.RegisterType<SessionFactoryProvider>().As<ISessionFactoryProvider>().SingleInstance();
        }
    }
}
