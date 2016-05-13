using AE.Common;
using Caliburn.Micro;
using System;

namespace AE.Presentation.ViewModels.Approaches.Impl
{
    public class ApproachDetailsViewModel : Screen, IApproachDetailsViewModel
    {
        private Guid idCache;
        private string nameCache;
        private CriteriaType criteriaCache;

        public ApproachDetailsViewModel()
        {
            this.Id = Guid.Empty;
            this.ApproachName = string.Empty;
        }

        public Guid Id
        {
            get { return this.idCache; }
            private set
            {
                this.idCache = value;
                this.NotifyOfPropertyChange(() => this.Id);
            }
        }

        public string ApproachName
        {
            get { return this.nameCache; }
            private set
            {
                this.nameCache = value;
                this.NotifyOfPropertyChange(() => this.ApproachName);
            }
        }

        public CriteriaType Criteria
        {
            get { return this.criteriaCache; }
            private set
            {
                this.criteriaCache = value;
                this.NotifyOfPropertyChange(() => this.Criteria);
            }
        }

        public void Load(Guid id, string name, CriteriaType criteria)
        {
            this.Id = id;
            this.ApproachName = name;
            this.Criteria = criteria;
        }
    }
}
