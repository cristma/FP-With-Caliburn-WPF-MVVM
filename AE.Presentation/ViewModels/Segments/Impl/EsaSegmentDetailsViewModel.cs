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
    public class EsaSegmentDetailsViewModel : Screen, IEsaSegmentDetailsViewModel
    {
        private readonly IApproachService esaService;

        private Guid idCache;
        private double altitudeCache;
        private double centerLatitudeCache;
        private double centerLongitudeCache;
        private double radiusCache;

        public EsaSegmentDetailsViewModel(
            IApproachService esaService)
        {
            if (esaService == null)
                throw new ArgumentNullException("esaService");

            this.esaService = esaService;
        }

        public Guid Id 
        { 
            get { return this.idCache; }
            private set { this.idCache = value; }
        }

        public double Altitude
        {
            get { return this.altitudeCache; }
            private set 
            { 
                this.altitudeCache = value;
                this.NotifyOfPropertyChange(() => this.Altitude);
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

        public double Radius
        {
            get { return this.radiusCache; }
            set
            {
                this.radiusCache = value;
                this.NotifyOfPropertyChange(() => this.Radius);
            }
        }

        public void Load(Guid id)
        {
            EsaSummaryDto dto = this.esaService.GetEsa(id);

            this.Id = dto.Id;
            this.Altitude = dto.Altitude;
            this.CenterLatitude = dto.CenterLatitude;
            this.CenterLongitude = dto.CenterLongitude;
            this.Radius = dto.Radius;
        }
    }
}
