using AE.FlightProcedures.Domain.BoilerPlate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Segments
{
    internal class Location : ValueObject
    {
        public Location(Latitude latitude, Longitude longitude)
        {
            if (latitude == null)
                throw new ArgumentNullException("latitude");
            if (longitude == null)
                throw new ArgumentNullException("longitude");

            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public Latitude Latitude { get; private set; }
        public Longitude Longitude { get; private set; }
    }
}