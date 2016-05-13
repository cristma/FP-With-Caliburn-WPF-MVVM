using AE.Common;
using Caliburn.Micro;
using System;

namespace AE.Presentation.ViewModels.Approaches
{
    public interface IApproachEditViewModel : IScreen
    {
        string ApproachName { get; set; }
        CriteriaType SelectedCriteria { get; set; }
        IObservableCollection<CriteriaType> Criterias { get; }
        bool CanOk { get; }
        void Ok();
        void Load(Guid id);
    }
}