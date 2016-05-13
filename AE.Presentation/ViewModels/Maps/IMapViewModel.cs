using Caliburn.Micro;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms.Integration;

namespace AE.Presentation.ViewModels.Maps
{
    public interface IMapViewModel : IScreen
    {
        WindowsFormsHost HostControl { get; }
        GMapControl MapControl { get; }
        GMapOverlay AirspacesOverlay { get; }
        void ZoomTo(double latitude, double longitude);
        void AddPolygon(IList<Tuple<double, double>> points, string name);
    }
}
