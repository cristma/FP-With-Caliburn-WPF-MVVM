using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Presentation.ViewModels.Deviations
{
    public interface IDeviationCollectionViewModel : IScreen
    {
        IObservableCollection<IDeviationSummaryViewModel> Deviations { get; }
    }
}
