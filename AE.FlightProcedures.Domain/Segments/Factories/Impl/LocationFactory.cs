using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Segments.Factories.Impl
{
    internal class LocationFactory : ILocationFactory
    {
        public Location CreateLocation(double latitude, double longitude)
        {
            Latitude latitudeVo = new Latitude(latitude);
            Longitude longitudeVo = new Longitude(longitude);
            Location location = new Location(latitudeVo, longitudeVo);

            return location;
        }
    }
}