using AE.FlightProcedures.AppServices.Modules;
using AE.Presentation.ViewModels;
using AE.Presentation.ViewModels.Approaches;
using AE.Presentation.ViewModels.Approaches.Impl;
using AE.Presentation.ViewModels.Deviations;
using AE.Presentation.ViewModels.Deviations.Impl;
using AE.Presentation.ViewModels.Impl;
using AE.Presentation.ViewModels.Maps;
using AE.Presentation.ViewModels.Maps.Impl;
using AE.Presentation.ViewModels.Segments;
using AE.Presentation.ViewModels.Segments.Impl;
using Autofac;
using Caliburn.Micro;

namespace AE.Presentation.Modules
{
    public class PresentationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<AppServicesModule>();

            builder.RegisterType<WindowManager>().As<IWindowManager>();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>();
            builder.RegisterType<ApproachCollectionViewModel>().As<IApproachCollectionViewModel>();
            builder.RegisterType<ApproachDetailsViewModel>().As<IApproachDetailsViewModel>();
            builder.RegisterType<ApproachEditViewModel>().As<IApproachEditViewModel>();
            builder.RegisterType<ApproachViewModel>().As<IApproachViewModel>();
            builder.RegisterType<EsaSegmentDetailsViewModel>().As<IEsaSegmentDetailsViewModel>();
            builder.RegisterType<EsaEditViewModel>().As<IEsaEditViewModel>();
            builder.RegisterType<MapViewModel>().As<IMapViewModel>();
            builder.RegisterType<DeviationCollectionViewModel>().As<IDeviationCollectionViewModel>();
            builder.RegisterType<DeviationSummaryViewModel>().As<IDeviationSummaryViewModel>();
            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
        }
    }
}
