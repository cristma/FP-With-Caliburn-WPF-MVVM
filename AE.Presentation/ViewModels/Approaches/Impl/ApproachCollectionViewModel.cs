using AE.FlightProcedures.AppServices.Approaches;
using AE.FlightProcedures.AppServices.Approaches.Impl.Dtos;
using Caliburn.Micro;
using System;
using System.Collections.Generic;

namespace AE.Presentation.ViewModels.Approaches.Impl
{
    public class ApproachCollectionViewModel : Screen, IApproachCollectionViewModel
    {
        private readonly Func<IApproachEditViewModel> editViewModelFactory;
        private readonly Func<IApproachDetailsViewModel> detailsViewModelFactory;
        private readonly Func<IApproachViewModel> approachViewModelFactory;
        private readonly IApproachService approachService;
        private readonly IWindowManager windowManager;

        private IApproachDetailsViewModel selectedApproachCache;
        private IObservableCollection<IApproachDetailsViewModel> approachesCache;

        public ApproachCollectionViewModel(
            Func<IApproachEditViewModel> editViewModelFactory, 
            Func<IApproachDetailsViewModel> detailsViewModelFactory,
            Func<IApproachViewModel> approachViewModelFactory, 
            IApproachService approachService, 
            IWindowManager windowManager)
        {
            if (editViewModelFactory == null)
                throw new ArgumentNullException("editViewModelFactory");
            if (detailsViewModelFactory == null)
                throw new ArgumentNullException("detailsViewModelFactory");
            if (approachViewModelFactory == null)
                throw new ArgumentNullException("approachViewModelFactory");
            if (approachService == null)
                throw new ArgumentNullException("approachService");
            if (windowManager == null)
                throw new ArgumentNullException("windowManager");

            this.editViewModelFactory = editViewModelFactory;
            this.detailsViewModelFactory = detailsViewModelFactory;
            this.approachViewModelFactory = approachViewModelFactory;
            this.approachService = approachService;
            this.windowManager = windowManager;

            this.approachesCache = new BindableCollection<IApproachDetailsViewModel>();
        }

        public IApproachDetailsViewModel SelectedApproache 
        {
            get { return this.selectedApproachCache; }
            set
            {
                this.selectedApproachCache = value;
                this.NotifyOfPropertyChange(() => this.SelectedApproache);
                this.NotifyOfPropertyChange(() => this.CanEdit);
                this.NotifyOfPropertyChange(() => this.CanDelete);
                this.NotifyOfPropertyChange(() => this.CanOpen);
            }
        }

        public IObservableCollection<IApproachDetailsViewModel> Approaches 
        {
            get { return this.approachesCache; }
        }

        public bool CanEdit { get { return this.SelectedApproache != null; } }
        public bool CanDelete { get { return this.SelectedApproache != null; } }
        public bool CanOpen { get { return this.SelectedApproache != null; } }
        public bool CanCreate { get { return true; } }

        public void Edit()
        {
            IApproachEditViewModel editViewModel = this.editViewModelFactory.Invoke();
            editViewModel.Load(this.SelectedApproache.Id);
            this.windowManager.ShowDialog(editViewModel);
            this.ReloadApproaches();
        }

        public void Delete()
        {
        }

        public void Create()
        {
            IApproachEditViewModel editViewModel = this.editViewModelFactory.Invoke();
            this.windowManager.ShowDialog(editViewModel);
            this.ReloadApproaches();
        }

        public void Open()
        {
            IApproachViewModel approachViewModel = this.approachViewModelFactory.Invoke();
            approachViewModel.ConductWith(this);
            approachViewModel.Load(this.SelectedApproache);
            this.windowManager.ShowDialog(approachViewModel);
        }

        private void ReloadApproaches()
        {
            this.SelectedApproache = null;
            approachesCache.Clear();
            IReadOnlyList<ApproachSummaryDto> dtos = this.approachService.GetApproaches();

            foreach(ApproachSummaryDto dto in dtos)
            {
                IApproachDetailsViewModel detailsViewModel = this.detailsViewModelFactory.Invoke();
                detailsViewModel.Load(dto.Id, dto.Name, dto.Criteria);
                approachesCache.Add(detailsViewModel);
            }

            this.NotifyOfPropertyChange(() => this.Approaches);
            this.NotifyOfPropertyChange(() => this.SelectedApproache);
            this.NotifyOfPropertyChange(() => this.CanCreate);
            this.NotifyOfPropertyChange(() => this.CanDelete);
            this.NotifyOfPropertyChange(() => this.CanEdit);
            this.NotifyOfPropertyChange(() => this.CanOpen);
        }

        protected override void OnInitialize()
        {
            this.ReloadApproaches();
        }
    }
}