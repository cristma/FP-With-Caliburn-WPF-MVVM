using AE.FlightProcedures.Domain.Approaches.Factories;
using AE.FlightProcedures.Domain.Approaches.Factories.Impl;
using AE.FlightProcedures.Domain.BoilerPlate;
using AE.FlightProcedures.Domain.Calculations.Common;
using AE.FlightProcedures.Domain.Calculations.Common.Impl;
using AE.FlightProcedures.Domain.Construction.Segments.Airspaces;
using AE.FlightProcedures.Domain.Construction.Segments.Airspaces.Impl;
using AE.FlightProcedures.Domain.Evaluation.Deviations.Factories;
using AE.FlightProcedures.Domain.Evaluation.Deviations.Factories.Impl;
using AE.FlightProcedures.Domain.Evaluation.Observers;
using AE.FlightProcedures.Domain.Evaluation.Observers.Impl;
using AE.FlightProcedures.Domain.Segments.Factories;
using AE.FlightProcedures.Domain.Segments.Factories.Impl;
using Autofac;

namespace AE.FlightProcedures.Domain.Modules
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApproachFactory>().As<IApproachFactory>();
            builder.RegisterType<ConstructFactory>().As<IConstructFactory>();
            builder.RegisterType<EsaFactory>().As<IEsaFactory>();
            builder.RegisterType<LocationFactory>().As<ILocationFactory>();
            builder.RegisterType<ArcDerivation>().As<IArcDerivation>();
            builder.RegisterType<LocationDerivation>().As<ILocationDerivation>();
            builder.RegisterType<EsaConstructBuilder>().As<IEsaConstructBuilder>();
            builder.RegisterType<DeviationFactory>().As<IDeviationFactory>();
            builder.RegisterType<DeviationObserver>().As<IDeviationObserver>().SingleInstance();
        }
    }
}
