using Caliburn.Micro;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.Integration;

namespace AE.Presentation.ViewModels.Maps.Impl
{
    public class MapViewModel : Screen, IMapViewModel
    {
        private WindowsFormsHost hostControlCache;

        public MapViewModel()
        {
            this.MapControl = new GMapControl();
            this.AirspacesOverlay = new GMapOverlay();
            GMap.NET.GMaps.Instance.Mode = AccessMode.ServerAndCache;

            this.MapControl.Overlays.Add(this.AirspacesOverlay);
        }

        public WindowsFormsHost HostControl 
        { 
            get
            {
                if(this.hostControlCache == null)
                {
                    this.hostControlCache = new WindowsFormsHost()
                    {
                        Child = this.MapControl
                    };
                }

                return this.hostControlCache;
            }
        }

        public GMapControl MapControl { get; private set; }
        public GMapOverlay AirspacesOverlay { get; private set; }

        protected override void OnInitialize()
        {
            this.MapControl.MapProvider = GMapProviders.GoogleMap;
            MapControl.MaxZoom = 17;
            MapControl.MinZoom = 1;
            MapControl.Zoom = 10;
        }

        public void ZoomTo(double latitude, double longitude)
        {
            this.MapControl.Position = new PointLatLng(latitude, longitude);
        }

        public void AddPolygon(IList<Tuple<double, double>> points, string name)
        {
            List<PointLatLng> coords = new List<PointLatLng>();
            foreach(Tuple<double, double> point in points)
            {
                coords.Add(new PointLatLng(point.Item1, point.Item2));
            }

            GMapPolygon polygon = new GMapPolygon(coords, name);
            polygon.Stroke = new Pen(Color.Red, 1);
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            AirspacesOverlay.Polygons.Add(polygon);
        }
    }
}