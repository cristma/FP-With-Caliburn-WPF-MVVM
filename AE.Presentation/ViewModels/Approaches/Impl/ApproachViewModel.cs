using AE.FlightProcedures.AppServices.Approaches;
using AE.FlightProcedures.AppServices.Segments;
using AE.Presentation.Messages;
using AE.Presentation.ViewModels.Deviations;
using AE.Presentation.ViewModels.Maps;
using AE.Presentation.ViewModels.Segments;
using Caliburn.Micro;
using System;

namespace AE.Presentation.ViewModels.Approaches.Impl
{
    public class ApproachViewModel : Screen, IApproachViewModel
    {
        private readonly Func<IEsaSegmentDetailsViewModel> esaDetailsComponentFactory;
        private readonly Func<IEsaEditViewModel> esaEditViewModelFactory;
        private readonly IMapViewModel mapViewModel;
        private readonly IApproachService approachService;
        private readonly IWindowManager windowManager;
        private readonly IEventAggregator eventAggregator;
        private readonly IDeviationCollectionViewModel deviationViewer;

        private IEsaSegmentDetailsViewModel esaDetailsComponent;
        private IApproachDetailsViewModel detailsViewModel;

        public ApproachViewModel(
            Func<IEsaSegmentDetailsViewModel> esaDetailsComponentFactory,
            Func<IEsaEditViewModel> esaEditViewModelFactory, 
            IDeviationCollectionViewModel deviationViewer, 
            IMapViewModel mapViewModel,
            IApproachService approachService,
            IWindowManager windowManager, 
            IEventAggregator eventAggregator)
        {
            if (esaDetailsComponentFactory == null)
                throw new ArgumentNullException("esaDetailsComponentFactory");
            if (esaEditViewModelFactory == null)
                throw new ArgumentNullException("esaEditViewModelFactory");
            if (deviationViewer == null)
                throw new ArgumentNullException("deviationViewer");
            if (mapViewModel == null)
                throw new ArgumentNullException("mapViewModel");
            if (approachService == null)
                throw new ArgumentNullException("approachService");
            if (windowManager == null)
                throw new ArgumentNullException("windowManager");
            if (eventAggregator == null)
                throw new ArgumentNullException("eventAggregator");

            this.esaDetailsComponentFactory = esaDetailsComponentFactory;
            this.esaEditViewModelFactory = esaEditViewModelFactory;
            this.deviationViewer = deviationViewer;
            this.mapViewModel = mapViewModel;
            this.approachService = approachService;
            this.windowManager = windowManager;
            this.eventAggregator = eventAggregator;
        }

        public IEsaSegmentDetailsViewModel EsaDetailsComponent 
        { 
            get { return this.esaDetailsComponent; } 
            set
            {
                this.esaDetailsComponent = value;
                this.NotifyOfPropertyChange(() => this.EsaDetailsComponent);
            }
        }

        public bool HasEsa { get { return this.EsaDetailsComponent != null; } }
        public bool HasMsa { get { return false; } }
        public bool HasRoute { get { return false; } }
        public bool CanCreateEsa { get { return this.detailsViewModel.Criteria != Common.CriteriaType.ICAO; } }

        public string ApproachName { get { return this.detailsViewModel.ApproachName; } }

        public void CreateEsa()
        {
            IEsaEditViewModel editViewModel = this.esaEditViewModelFactory.Invoke();

            if(this.HasEsa)
            {
                editViewModel.Load(this.EsaDetailsComponent);
            }
            else
            {
                editViewModel.Load(this.detailsViewModel.Id);
            }

            this.windowManager.ShowDialog(editViewModel);
            this.Load(this.detailsViewModel);
            this.eventAggregator.Publish(new DeviationsUpdatedMessage());
        }

        public void Load(IApproachDetailsViewModel approach)
        {
            this.detailsViewModel = approach;

            if (approachService.HasEsa(approach.Id))
            {
                this.EsaDetailsComponent = this.esaDetailsComponentFactory.Invoke();
                this.EsaDetailsComponent.Load(approach.Id);
                this.EsaDetailsComponent.ConductWith(this);
                this.mapViewModel.AddPolygon(this.approachService.GetConstruct(approach.Id), "ESA");
                this.mapViewModel.ZoomTo(this.EsaDetailsComponent.CenterLatitude, this.EsaDetailsComponent.CenterLongitude);
            }

            this.NotifyOfPropertyChange(() => this.ApproachName);
            this.eventAggregator.Publish(new DeviationsUpdatedMessage());
        }

        public void ShowMap()
        {
            this.windowManager.ShowWindow(this.mapViewModel);
        }

        public void ShowDeviations()
        {
            this.windowManager.ShowWindow(this.deviationViewer);
        }
    }
}