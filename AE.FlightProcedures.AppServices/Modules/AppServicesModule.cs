using AE.FlightProcedures.AppServices.Approaches;
using AE.FlightProcedures.AppServices.Approaches.Builders;
using AE.FlightProcedures.AppServices.Approaches.Builders.Impl;
using AE.FlightProcedures.AppServices.Approaches.Impl;
using AE.FlightProcedures.AppServices.Deviations;
using AE.FlightProcedures.AppServices.Deviations.Builders;
using AE.FlightProcedures.AppServices.Deviations.Builders.Impl;
using AE.FlightProcedures.AppServices.Deviations.Impl;
using AE.FlightProcedures.AppServices.Segments;
using AE.FlightProcedures.AppServices.Segments.Impl;
using AE.FlightProcedures.Domain.Modules;
using AE.Infrastructure.Modules;
using Autofac;
using Autofac.Core.Activators.Reflection;
using System.Reflection;

namespace AE.FlightProcedures.AppServices.Modules
{
    public class AppServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DomainModule>();
            builder.RegisterModule<InfrastructureModule>();

            builder.RegisterType<ApproachDtoBuilder>().As<IApproachDtoBuilder>();
            builder.RegisterType<ApproachService>().As<IApproachService>().FindConstructorsWith(
                new DefaultConstructorFinder(type => type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)));
            builder.RegisterType<EsaDtoBuilder>().As<IEsaDtoBuilder>();
            builder.RegisterType<DeviationService>().As<IDeviationService>();
            builder.RegisterType<DeviationDtoBuilder>().As<IDeviationDtoBuilder>();
            builder.RegisterType<DeviationServiceFacade>().As<IDeviationServiceFacade>().FindConstructorsWith(
                new DefaultConstructorFinder(type => type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)));
        }
    }
}