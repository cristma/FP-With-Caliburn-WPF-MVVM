using AE.FlightProcedures.AppServices.Deviations;
using AE.FlightProcedures.AppServices.Deviations.Impl.Dtos;
using AE.Presentation.Messages;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Presentation.ViewModels.Deviations.Impl
{
    public class DeviationCollectionViewModel : Screen, IDeviationCollectionViewModel, IHandle<DeviationsUpdatedMessage>
    {
        private readonly IDeviationServiceFacade deviationService;
        private readonly Func<IDeviationSummaryViewModel> deviationSummaryFactory;
        private readonly IEventAggregator eventAggregator;
        private readonly IObservableCollection<IDeviationSummaryViewModel> deviationsCache;

        public DeviationCollectionViewModel(
            IDeviationServiceFacade deviationService,
            Func<IDeviationSummaryViewModel> deviationSummaryFactory, 
            IEventAggregator eventAggregator)
        {
            if (deviationService == null)
                throw new ArgumentNullException("deviationService");
            if (deviationSummaryFactory == null)
                throw new ArgumentNullException("deviationSummaryFactory");
            if (eventAggregator == null)
                throw new ArgumentNullException("eventAggregator");

            this.deviationService = deviationService;
            this.deviationSummaryFactory = deviationSummaryFactory;
            this.eventAggregator = eventAggregator;
            this.deviationsCache = new BindableCollection<IDeviationSummaryViewModel>();
        }

        public IObservableCollection<IDeviationSummaryViewModel> Deviations
        {
            get { return this.deviationsCache; }
        }

        private void ReloadDeviations()
        {
            IList<DeviationSummaryDto> dtos = this.deviationService.GetDeviations();
            this.Deviations.Clear();
            
            foreach(DeviationSummaryDto dto in dtos)
            {
                IDeviationSummaryViewModel summaryViewModel = this.deviationSummaryFactory.Invoke();
                summaryViewModel.Load(dto);

                this.Deviations.Add(summaryViewModel);
            }

            this.NotifyOfPropertyChange(() => this.Deviations);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            this.eventAggregator.Subscribe(this);
            this.ReloadDeviations();
        }

        public void Handle(DeviationsUpdatedMessage message)
        {
            this.ReloadDeviations();
        }
    }
}