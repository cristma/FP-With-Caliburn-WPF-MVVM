using AE.FlightProcedures.AppServices.Approaches;
using AE.FlightProcedures.AppServices.Segments;
using AE.FlightProcedures.AppServices.Segments.Impl.Dtos;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Presentation.ViewModels.Segments.Impl
{
    public class EsaEditViewModel : Screen, IEsaEditViewModel
    {
        private readonly IApproachService service;

        private double altitudeCache;
        private double radiusCache;
        private double centerLatitudeCache;
        private double centerLongitudeCache;

        public EsaEditViewModel(
            IApproachService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;

            this.Altitude = 0;
            this.Radius = 0;
            this.CenterLatitude = 0;
            this.CenterLongitude = 0;

            this.DisplayName = "ESA Segment";
        }

        private IEsaSegmentDetailsViewModel Details { get; set; }

        public Guid Id { get; private set; }

        public double Altitude 
        {
            get { return this.altitudeCache; }
            set
            {
                this.altitudeCache = value;
                this.NotifyOfPropertyChange(() => this.Altitude);
            }
        }

        public double Radius 
        {
            get { return this.radiusCache; }
            set
            {
                this.radiusCache = value;
                this.NotifyOfPropertyChange(() => this.Radius);
                this.NotifyOfPropertyChange(() => this.CanOk);
            }
        }

        public double CenterLatitude 
        {
            get { return this.centerLatitudeCache; }
            set
            {
                this.centerLatitudeCache = value;
                this.NotifyOfPropertyChange(() => this.CenterLatitude);
            }
        }

        public double CenterLongitude 
        {
            get { return this.centerLongitudeCache; }
            set
            {
                this.centerLongitudeCache = value;
                this.NotifyOfPropertyChange(() => this.CenterLongitude);
            }
        }

        public bool CanOk 
        {
            get { return this.Radius > 100; }
        }

        public void Ok()
        {
            EsaSummaryDto dto = new EsaSummaryDto(this.Id, this.Altitude, this.Radius, this.CenterLatitude, this.CenterLongitude);
            this.service.CreateEsa(dto);

            this.TryClose();
        }

        public void Load(IEsaSegmentDetailsViewModel esa)
        {
            this.Details = esa;

            this.Id = esa.Id;
            this.Altitude = esa.Altitude;
            this.Radius = esa.Radius;
            this.CenterLatitude = esa.CenterLatitude;
            this.CenterLongitude = esa.CenterLongitude;
        }

        public void Load(Guid id)
        {
            this.Id = id;
        }
    }
}