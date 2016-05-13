using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Presentation.ViewModels.Segments
{
    public interface IEsaEditViewModel : IScreen
    {
        double Altitude { get; set; }
        double Radius { get; set; }
        double CenterLatitude { get; set; }
        double CenterLongitude { get; set; }
        bool CanOk { get; }
        void Ok();
        void Load(IEsaSegmentDetailsViewModel esa);
        void Load(Guid id);
    }
}
