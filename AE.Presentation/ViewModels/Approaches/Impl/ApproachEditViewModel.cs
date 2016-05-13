using AE.Common;
using AE.FlightProcedures.AppServices.Approaches;
using AE.FlightProcedures.AppServices.Approaches.Impl.Dtos;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Presentation.ViewModels.Approaches.Impl
{
    public class ApproachEditViewModel : Screen, IApproachEditViewModel
    {
        private readonly IApproachService approachService;

        private Guid idCache;
        private string nameCache;
        private CriteriaType selectedCriteriaCache;
        private IObservableCollection<CriteriaType> criteriaCache;

        public ApproachEditViewModel(
            IApproachService approachService)
        {
            if (approachService == null)
                throw new ArgumentNullException("approachService");

            this.approachService = approachService;

            this.criteriaCache = new BindableCollection<CriteriaType>();
            this.criteriaCache.Add(CriteriaType.ICAO);
            this.criteriaCache.Add(CriteriaType.NATO);

            // Defaults
            this.Id = Guid.Empty;
            this.SelectedCriteria = CriteriaType.UNDEFINED;
            this.ApproachName = string.Empty;
        }

        private Guid Id
        {
            get
            {
                return this.idCache;
            }

            set
            {
                this.idCache = value;
            }
        }

        public string ApproachName 
        { 
            get { return this.nameCache; }
            set 
            { 
                this.nameCache = value;
                this.NotifyOfPropertyChange(() => this.ApproachName);
                this.NotifyOfPropertyChange(() => this.CanOk);
            }
        }

        public CriteriaType SelectedCriteria
        {
            get { return this.selectedCriteriaCache; }
            set 
            { 
                this.selectedCriteriaCache = value; 
                this.NotifyOfPropertyChange(() => this.SelectedCriteria);
                this.NotifyOfPropertyChange(() => this.CanOk);
            }
        }

        public IObservableCollection<CriteriaType> Criterias
        {
            get { return this.criteriaCache; }
        }

        public bool CanOk
        {
            get
            {
                return !string.IsNullOrEmpty(this.ApproachName) && this.SelectedCriteria != CriteriaType.UNDEFINED;
            }
        }

        public void Ok()
        {
            this.Id = this.Id == Guid.Empty ? Guid.NewGuid() : this.Id;
            ApproachDetailsDto dto = new ApproachDetailsDto(this.Id, this.ApproachName, this.SelectedCriteria);
            this.approachService.CreateApproach(dto);
            this.TryClose();
        }

        public void Load(Guid id)
        {
            ApproachDetailsDto dto = this.approachService.GetApproach(id);

            this.Id = dto.Id;
            this.ApproachName = dto.Name;
            this.SelectedCriteria = dto.Criteria;
        }
    }
}
