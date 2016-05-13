using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Presentation.ViewModels.Segments
{
    public interface IEsaSegmentDetailsViewModel : IScreen
    {
        Guid Id { get; }
        double Altitude { get; }
        double CenterLatitude { get; }
        double CenterLongitude { get; }
        double Radius { get; }
        void Load(Guid id);
    }
}
