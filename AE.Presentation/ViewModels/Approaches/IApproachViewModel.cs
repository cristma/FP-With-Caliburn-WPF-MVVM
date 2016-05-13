using AE.Presentation.ViewModels.Segments;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Presentation.ViewModels.Approaches
{
    public interface IApproachViewModel : IScreen
    {
        IEsaSegmentDetailsViewModel EsaDetailsComponent { get; }
        bool HasEsa { get; }
        bool HasMsa { get; }
        bool HasRoute { get; }
        string ApproachName { get; }
        void Load(IApproachDetailsViewModel approach);
    }
}
