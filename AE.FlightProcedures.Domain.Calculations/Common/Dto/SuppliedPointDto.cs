using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Calculations.Common.Dto
{
    internal class SuppliedPointDto
    {
        public SuppliedPointDto(
            double latitude, 
            double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public SuppliedPointDto(DerivedPointDto derived)
        {
            this.Latitude = derived.Latitude;
            this.Longitude = derived.Longitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}