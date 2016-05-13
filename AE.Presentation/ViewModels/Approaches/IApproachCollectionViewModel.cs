using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Presentation.ViewModels.Approaches
{
    public interface IApproachCollectionViewModel : IScreen
    {
        IApproachDetailsViewModel SelectedApproache { get; set; }
        IObservableCollection<IApproachDetailsViewModel> Approaches { get; }
        bool CanEdit { get; }
        bool CanDelete { get; }
        bool CanOpen { get; }
        bool CanCreate { get; }
        void Edit();
        void Delete();
        void Create();
        void Open();
    }
}
