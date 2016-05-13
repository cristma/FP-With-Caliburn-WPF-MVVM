using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.AppServices.Segments.Impl.Dtos
{
    public class EsaSummaryDto
    {
        public EsaSummaryDto(
            Guid id, 
            double altitude, 
            double radius, 
            double centerLatitude, 
            double centerLongitude)
        {
            this.Id = id;
            this.Altitude = altitude;
            this.Radius = radius;
            this.CenterLatitude = centerLatitude;
            this.CenterLongitude = centerLongitude;
        }

        public Guid Id { get; private set; }
        public double Altitude { get; private set; }
        public double Radius { get; private set; }
        public double CenterLatitude { get; private set; }
        public double CenterLongitude { get; private set; }
    }
}